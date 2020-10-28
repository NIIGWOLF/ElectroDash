using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TransportationBlock : Character
{
    [SerializeField] public List<MoveTurtle> moveList = new List<MoveTurtle>();
    int indexList = 0; //текущий индекс движения
    Sequence seq;
    Vector3Int movePos; //позиция прибытия платформы по индексу из листа

    override protected void Start()
    {
        backPos = Vector3Int.CeilToInt(transform.position);
        tileMap = ScriptManager.objectManager.tilemap;
        currentPos = Vector3Int.CeilToInt(transform.position);
        timeleft = time;

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
    }
    void Update()
    {
        if (isMove)
        {

        }
        else
        {
            if (timeleft < 0)
            {

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
                seq = DOTween.Sequence().Append(transform.DOMove(nextPos, 1));
                seq.OnComplete(CompliteMove);
                seq.OnPause(PauseMove);

                indexList++;
                if (indexList >= moveList.Count)
                    indexList = 0;


                movePos = nextPos;
                backPos = currentPos;
                isMove = true;
            }
            else
            {
                timeleft -= Time.deltaTime;
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
            timeleft = time;
            currentPos = nextPos;
        }
        else
        {
            PauseMove();
        }
        Debug.Log("Finish Block");
    }

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
