using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace VRC.SDKBase
{
	public class VRC_SceneDescriptor : Behaviour
	{
		public VRC_SceneDescriptor(IntPtr newPtr) : base(newPtr) =>
			ptr = newPtr;


		public enum SpawnOrientation
		{
			Default,
			AlignPlayerWithSpawnPoint,
			AlignRoomWithSpawnPoint
		}
	}
}
