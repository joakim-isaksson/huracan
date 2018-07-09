using System;
using Random = UnityEngine.Random;

namespace Utils
{
	public interface WeightedObject<T>
	{
		float Weight { get; }
		T Value { get; }
	}
	
	public class WeightedArray<T>
	{
		private readonly T[] _objects;
		private readonly float[] _cumulativeWeights;
		private readonly float _maxWeight;

		public WeightedArray(WeightedObject<T>[] wObjects)
		{
			_objects = new T[wObjects.Length];
			_cumulativeWeights = new float[wObjects.Length];

			float cumulativeWeight = 0;
			for (var i = 0; i < wObjects.Length; ++i)
			{
				var obj = wObjects[i];
				cumulativeWeight += obj.Weight;
				_cumulativeWeights[i] = cumulativeWeight;
				_objects[i] = obj.Value;
			}
			_maxWeight = cumulativeWeight;
		}

		public T GetRandom()
		{
			var index = Array.BinarySearch(_cumulativeWeights, Random.value * _maxWeight);
			if (index < 0) index = ~index;
			return _objects[index];
		}
	}
}