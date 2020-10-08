using UnityEngine;

public class PlayerModel 
{
    private int hitPoint;
    private int maxHitPoint;
    private int _score;
    
    public PlayerModel(int _maxHitPoint)
    {
        maxHitPoint = _maxHitPoint;
        hitPoint = _maxHitPoint;
    }

    public int GetHitPoint()
    {
        return hitPoint;
    }

    public void ChangeHitPoint(int hpChange)
    {
        if (hpChange < 0)
        {
            hitPoint += hpChange;
            if (hitPoint <= 0)
            {
                hitPoint = 0;
            }
        }
        else
        {
            if (hitPoint < maxHitPoint)
            {
                hitPoint += hpChange;
                if (hitPoint > maxHitPoint)
                {
                    hitPoint = maxHitPoint;

                }
            }
        }
    }
}
