using UnityEngine;

public interface IHit
{
    void Hit(int damage, Vector3 point, bool isCritical = false);
    int GetHitRate();
}