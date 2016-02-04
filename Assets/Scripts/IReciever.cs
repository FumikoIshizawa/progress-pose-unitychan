using UnityEngine.EventSystems;

public interface IReciever : IEventSystemHandler {
  void OnRecieve(float value);
}
