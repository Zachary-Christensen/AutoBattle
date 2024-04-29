using System.Collections.Generic;
using AutoBattle.Enums;
using UnityEngine;


public class Gameboard : MonoBehaviour
{
    public static readonly float LEAVE_SIDES_OPEN_BY_PERCENT = (1 - (2 / (1 + Mathf.Sqrt(5)))) * 1.05f; // percent of the side that should not be overlapped by square. amount is for both sides combined
    public static readonly float BACKGROUND_RATIO = 4f / 3f;
    public SpriteRenderer _sr; // reference set in editor
    public float GetWidth => transform.localScale.x;
    public Vector2 GetTopLeftCorner =>  new Vector2(-_sr.bounds.extents.x, _sr.bounds.extents.y);
    public Vector2 GetBottomLeftCorner => new Vector2(-_sr.bounds.extents.x, -_sr.bounds.extents.y);
    public Bounds GetBounds => _sr.bounds;
    public float UnitScale = 1.0f;

    private Vector3[] _playerLanePosition;
    public List<Transform> _playerSpawnPoints; // set in editor
    private Vector3[] _enemyLanePosition;
    public List<Transform> _enemySpawnPoints; // set in editor

    private void Awake()
    {
        #region // scale background
        (float height, float width) = BGUtils.GetScreenSize();

        float scale;
        float defaultScale = 0.95f * width;
        if (height < width) // is landscape
        {
            if ((width - height) < (LEAVE_SIDES_OPEN_BY_PERCENT * width)) scale = (1 - LEAVE_SIDES_OPEN_BY_PERCENT) * width;
            else scale = height;
        }
        else // is portrait
        {
            if (height / width < 1.9f)//(height - width) < (LEAVE_SIDES_OPEN_BY_PERCENT * height))
            {
                scale = (1 - LEAVE_SIDES_OPEN_BY_PERCENT) * height / BACKGROUND_RATIO;
                print("Leave sides open scale set");
            }
            else
            {
                scale = defaultScale;
            }
        }
        if (scale > defaultScale)
        {
            scale = defaultScale;
            print("Scale too large, overridden to default");
        }
        transform.localScale = Vector2.one * scale;

        UnitScale = scale / 6f;
        #endregion // scale background
        
        // get and set after scaling background
        _playerLanePosition = new Vector3[] {
            _playerSpawnPoints[0].position,
            _playerSpawnPoints[1].position,
            _playerSpawnPoints[2].position
        };
        _enemyLanePosition = new Vector3[] {
            _enemySpawnPoints[0].position,
            _enemySpawnPoints[1].position,
            _enemySpawnPoints[2].position
        };
    }


    public Vector3 GetPlayerLanePosition(Lane lane) 
    {
        return _playerLanePosition[(int)lane];
    }

    public Vector3 GetEnemyLanePosition(Lane lane)
    {
        return _enemyLanePosition[(int)lane];
    }



}