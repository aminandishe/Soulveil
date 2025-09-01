using System.Collections.Generic;
using System.Linq;
using Core.Systems.Abstractions;

namespace Core.Containers
{
    public class SystemContainer
    {
        private readonly List<StarterSystem> _starterSystems;
        private readonly List<GeneralSystem> _generalSystems;
        private readonly List<EndingSystem> _endingSystems;
        private readonly List<GeneralSystem> _activeSystems;
        private readonly List<GeneralSystem> _systemsToActive;
        private readonly List<GeneralSystem> _systemsToDeActive;

        private readonly Dictionary<GeneralSystem, int> _systemOrderings;

        public SystemContainer(
            StarterSystem[] starterGamePlaySystems,
            GeneralSystem[] generalGamePlaySystems)
        {
            _activeSystems = new List<GeneralSystem>();
            _systemsToActive = new List<GeneralSystem>();
            _systemsToDeActive = new List<GeneralSystem>();
            _starterSystems = new List<StarterSystem>(starterGamePlaySystems);

            _generalSystems = new List<GeneralSystem>(generalGamePlaySystems);
            _systemOrderings = new Dictionary<GeneralSystem, int>();

            StoreSystemsOrderings();
        }

        private void StoreSystemsOrderings()
        {
            for (var i = 0; i < _generalSystems.Count; i++)
            {
                _systemOrderings.Add(_generalSystems[i], i);
            }
        }

        public void Start()
        {
            foreach (var currentSystem in _starterSystems)
            {
                currentSystem.Start();
            }

            ActiveGeneralSystems();
        }

        private void ActiveGeneralSystems()
        {
            _activeSystems.AddRange(_generalSystems);
        }

        public void Update()
        {
            ActivateRequestedSystems();
            foreach (var system in _activeSystems)
                system.Update();

            DeActivateRequestedSystems();
        }

        private void ActivateRequestedSystems()
        {
            if (_systemsToActive.Count == 0)
                return;
            var notExistsSystems = _systemsToActive.Where(system => !_activeSystems.Contains(system));
            foreach (var system in notExistsSystems)
            {
                _activeSystems.Add(system);
                system.OnActivated();
            }

            _activeSystems.Sort((system, playSystem) =>
                _systemOrderings[system].CompareTo(_systemOrderings[playSystem]));
            _systemsToActive.Clear();
        }

        private void DeActivateRequestedSystems()
        {
            if (_systemsToDeActive.Count == 0)
                return;

            foreach (var system in _systemsToDeActive)
            {
                _activeSystems.Remove(system);
                system.OnDeActivated();
            }

            _systemsToDeActive.Clear();
        }

        public void ActiveSystem<T>() where T : GeneralSystem
        {
            var system = GetSystem<T>();
            _systemsToActive.Add(system);
        }

        public void DeactivateSystem<T>() where T : GeneralSystem
        {
            var system = _generalSystems.Where(gs => gs is T).ToList();
            _systemsToDeActive.AddRange(system);
        }

        private T GetSystem<T>() where T : GeneralSystem
        {
            foreach (var system in _generalSystems)
            {
                if (system is T playSystem)
                    return playSystem;
            }

            return default;
        }
    }
}