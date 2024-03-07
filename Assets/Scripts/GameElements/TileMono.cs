using System.Collections.Generic;
using NecatiAkpinar.Abstractions;
using NecatiAkpinar.Data;
using NecatiAkpinar.Misc;
using UnityEngine;

namespace NecatiApinar.GameElements
{
    public class TileMono : MonoBehaviour
    {
        private Vector2Int _coordinates;
        private Dictionary<TileDirectionType, TileMono> _neighbours;
        private BaseTileElement _tileElement;
        private SO_TileMonoData _data;

        public Vector2Int Coordinates => _coordinates;
        public Dictionary<TileDirectionType, TileMono> Neighbours => _neighbours;
        public BaseTileElement TileElement => _tileElement;

        public void Init(SO_TileMonoData tileMonoData, int rowX, int columnY)
        {
            _data = tileMonoData;
            _coordinates = new Vector2Int(rowX, columnY);
            transform.position = new Vector3(_coordinates.x, _coordinates.y, transform.position.z);
        }

        public void SetNeighbours(Dictionary<TileDirectionType, TileMono> neighbours)
        {
            _neighbours = neighbours;
        }

        public void SetTileElement(BaseTileElement tileElement)
        {
            _tileElement = tileElement;
            if (tileElement != null)
                _tileElement.Init(this);
        }
    }
}