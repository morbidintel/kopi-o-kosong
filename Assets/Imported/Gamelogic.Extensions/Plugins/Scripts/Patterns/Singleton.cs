// Copyright Gamelogic (c) http://www.gamelogic.co.za

using Gamelogic.Extensions.Internal;
using UnityEngine;
using System.Linq;

namespace Gamelogic.Extensions
{
	/// <summary>
	/// Generic Implementation of a Singleton MonoBehaviour.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[Version(1)]
	[AddComponentMenu("Gamelogic/Extensions/Singleton")]
	//	[HelpURL("http://gamelogic.co.za/documentation/extensions/?topic=html/T-Gamelogic.Extensions.Singleton-1.htm")]
	public class Singleton<T> : GLMonoBehaviour where T : MonoBehaviour
	{
		#region  Properties

		/// <summary>
		/// Returns the instance of this singleton.
		/// </summary>
		public static T Instance
		{
			get
			{
				if (instance == null)
				{
					instance = FindObjectOfType<T>();

					//if (instance == null)
					//{
					//	Debug.LogError("An instance of " + typeof(T) + " is needed in the scene, but there is none.");
					//}
				}

				return instance;
			}
		}

		#endregion

		private static T instance;
	}
}
