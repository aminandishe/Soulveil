using System.Collections.Generic;
using System.Linq;
using Core.Systems.Abstractions;

namespace Core.Containers
{
    public class SystemContainer
    {
        private readonly List<StarterGamePlaySystem> _starterSystems;
        private readonly List<GeneralGamePlaySystem> _generalSystems;
        private readonly List<EndingGamePlaySystem> _endingSystems;
        private readonly List<GeneralGamePlaySystem> _activeSystems;
        private readonly List<GeneralGamePlaySystem> _systemsToActive;
        private readonly List<GeneralGamePlaySystem> _systemsToDeActive;

        private readonly Dictionary<GeneralGamePlaySystem, int> _systemOrderings;

        public SystemContainer(
            StarterGamePlaySystem[] starterGamePlaySystems,
            GeneralGamePlaySystem[] generalGamePlaySystems)
        {
            _activeSystems = new List<GeneralGamePlaySystem>();
            _systemsToActive = new List<GeneralGamePlaySystem>();
            _systemsToDeActive = new List<GeneralGamePlaySystem>();
            _starterSystems = new List<StarterGamePlaySystem>(starterGamePlaySystems);

            _generalSystems = new List<GeneralGamePlaySystem>(generalGamePlaySystems);
            _systemOrderings = new Dictionary<GeneralGamePlaySystem, int>();

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

        public void ActiveSystem<T>() where T : GeneralGamePlaySystem
        {
            var system = GetSystem<T>();
            _systemsToActive.Add(system);
        }

        public void DeactivateSystem<T>() where T : GeneralGamePlaySystem
        {
            var system = _generalSystems.Where(gs => gs is T).ToList();
            _systemsToDeActive.AddRange(system);
        }

        private T GetSystem<T>() where T : GeneralGamePlaySystem
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