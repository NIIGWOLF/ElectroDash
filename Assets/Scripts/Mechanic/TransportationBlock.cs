﻿using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Tilemaps;

public class TransportationBlock : MonoBehaviour
{
    protected bool isMove = false;
    protected Vector3Int backPos;
    protected Vector3Int nextPos = new Vector3Int(0, 0, 1);
    protected Vector3Int currentPos;
    protected Tilemap tileMap;
    //protected float timeleft = 1;
    protected float nextTime;
    public float time = 1;
    public float delayStart = 1;



    [SerializeField] public List<MoveTurtle> moveList = new List<MoveTurtle>();
    int indexList = 0; //текущий индекс движения
    Sequence seq;
    Vector3Int movePos; //позиция прибытия платформы по индексу из листа

    protected virtual void Start()
    {
        backPos = Vector3Int.CeilToInt(transform.position);
        tileMap = ScriptManager.objectManager.tilemap;
        currentPos = Vector3Int.CeilToInt(transform.position);
        //timeleft = delayStart;
        nextTime = ScriptManager.objectManager.timer.time - delayStart;

        for (int i = moveList.Count - 1; i >= 0; i--) // добавляем инвертированный лист
        {
            switch (moveList[i].direction)
            {
                case MoveTurtle.Direction.Up:
                    moveList.Add(new MoveTurtle(MoveTurtle.Direction.Down,moveList[i].blockCount));
                    break;
                case MoveTurtle.Direction.Down:
                    moveList.Add(new MoveTurtle(MoveTurtle.Direction.Up,moveList[i].blockCount));
                    break;
                case MoveTurtle.Direction.Left:
                    moveList.Add(new MoveTurtle(MoveTurtle.Direction.Right,moveList[i].blockCount));
                    break;
                case MoveTurtle.Direction.Right:
                    moveList.Add(new MoveTurtle(MoveTurtle.Direction.Left,moveList[i].blockCount));
                    break;
            }
        }
        StartIn();
    }

    protected virtual void StartIn(){}

    void Update()
    {
        if (isMove)
        {

        }
        else
        {
            if (ScriptManager.objectManager.timer.time <= nextTime)
            {
                nextTime -= (1 + time);
                switch (moveList[indexList].direction)
                {
                    case MoveTurtle.Direction.Up:
                        nextPos = currentPos + new Vector3Int(0, moveList[indexList].blockCount, 0);
                        break;
                    case MoveTurtle.Direction.Down:
                        nextPos = currentPos - new Vector3Int(0, moveList[indexList].blockCount, 0);
                        break;
                    case MoveTurtle.Direction.Left:
                        nextPos = currentPos - new Vector3Int(moveList[indexList].blockCount, 0, 0);
                        break;
                    case MoveTurtle.Direction.Right:
                        nextPos = currentPos + new Vector3Int(moveList[indexList].blockCount, 0, 0);
                        break;
                }
                seq = DOTween.Sequence().Append(transform.DOMove(nextPos, 1).SetEase(Ease.InOutCubic));
                seq.OnComplete(CompliteMove);
                seq.OnPause(PauseMove);

                indexList++;
                if (indexList >= moveList.Count)
                    indexList = 0;


                movePos = nextPos;
                backPos = currentPos;
                isMove = true;
                StartMove();
            }
        }
    }

    public void PauseMove()
    {
        var temp = backPos;
        backPos = nextPos;
        nextPos = temp;

        seq = DOTween.Sequence().Append(transform.DOMove(nextPos, 1));
        seq.OnComplete(CompliteMove);
        seq.OnPause(PauseMove);
        Debug.Log("Pause Block");
    }

    public void CompliteMove()
    {


        if (Vector3Int.RoundToInt(transform.position).Equals(movePos))
        {
            isMove = false;
            //timeleft = time;
            currentPos = nextPos;
            EndMove();
        }
        else
        {
            PauseMove();
        }
        //Debug.Log("Finish Block");
    }

    protected virtual void EndMove(){}
    protected virtual void StartMove(){}

    [System.Serializable]
    public class MoveTurtle
    {
        public enum Direction { Up, Down, Left, Right };
        public Direction direction;
        public int blockCount = 1;

        public MoveTurtle(Direction direction)
        {
            this.direction = direction;
        }

        public MoveTurtle(Direction direction, int blockCount)
        {
            this.direction = direction;
            this.blockCount = blockCount;
        }
    }
}
