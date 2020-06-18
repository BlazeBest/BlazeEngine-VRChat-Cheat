using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace VRC.SDKBase
{
	public class VRC_EventHandler : Behaviour
	{
		public VRC_EventHandler(IntPtr newPtr) : base(newPtr) =>
			ptr = newPtr;

		/*
		public static bool BooleanOp(VRC_EventHandler.VrcBooleanOp Op, bool Current)
		{
		}

		public int NetworkID
		{
			[Address(RVA = "0x18041E0C0", Offset = "0x41C6C0")]
			get
			{
			}
			[Address(RVA = "0x18052B0A0", Offset = "0x5296A0")]
			set
			{
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x00002838 File Offset: 0x00000A38
		private VRC_EventDispatcher Dispatcher
		{
			[Address(RVA = "0x182E84430", Offset = "0x2E82A30")]
			get
			{
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060002E1 RID: 737 RVA: 0x0000283C File Offset: 0x00000A3C
		// (set) Token: 0x060002E2 RID: 738 RVA: 0x00002840 File Offset: 0x00000A40
		public static VRC_EventHandler.GetNetworkIdDelegate GetInsitgatorId
		{
			[Address(RVA = "0x182E84570", Offset = "0x2E82B70")]
			get
			{
			}
			[Address(RVA = "0x182E845B0", Offset = "0x2E82BB0")]
			set
			{
			}
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x00002844 File Offset: 0x00000A44
		[Address(RVA = "0x182E82B50", Offset = "0x2E81150")]
		private void Awake()
		{
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00002848 File Offset: 0x00000A48
		[Address(RVA = "0x182E841F0", Offset = "0x2E827F0")]
		public void VrcAnimationEvent(AnimationEvent aEvent)
		{
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0000284C File Offset: 0x00000A4C
		[Address(RVA = "0x182E83250", Offset = "0x2E81850")]
		public static bool IsReceiverRequiredForEventType(VRC_EventHandler.VrcEventType eventType)
		{
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x00002850 File Offset: 0x00000A50
		[Address(RVA = "0x182E839F0", Offset = "0x2E81FF0")]
		public void TriggerEvent(VRC_EventHandler.VrcEvent e, VRC_EventHandler.VrcBroadcastType broadcast, [Optional] GameObject instagator, float fastForward = 0f)
		{
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00002854 File Offset: 0x00000A54
		[Address(RVA = "0x182E83020", Offset = "0x2E81620")]
		private void InternalTriggerEvent(VRC_EventHandler.VrcEvent e, VRC_EventHandler.VrcBroadcastType broadcast, int instagatorId, float fastForward)
		{
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x00002858 File Offset: 0x00000A58
		[Address(RVA = "0x182E836A0", Offset = "0x2E81CA0")]
		public void TriggerEvent(VRC_EventHandler.VrcEvent e, VRC_EventHandler.VrcBroadcastType broadcast, int instagatorId, float fastForward)
		{
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0000285C File Offset: 0x00000A5C
		[Address(RVA = "0x182E834F0", Offset = "0x2E81AF0")]
		public void TriggerEvent(string eventName, VRC_EventHandler.VrcBroadcastType broadcast, [Optional] GameObject instagator, int instagatorId = 0)
		{
		}

		// Token: 0x060002EA RID: 746 RVA: 0x00002860 File Offset: 0x00000A60
		[Address(RVA = "0x182E83840", Offset = "0x2E81E40")]
		public void TriggerEvent(string eventName, VRC_EventHandler.VrcBroadcastType broadcast, GameObject instagator, int instagatorId, float fastForward)
		{
		}

		// Token: 0x060002EB RID: 747 RVA: 0x00002864 File Offset: 0x00000A64
		[Address(RVA = "0x182E83350", Offset = "0x2E81950")]
		private void OnValidate()
		{
		}

		// Token: 0x060002EC RID: 748 RVA: 0x00002868 File Offset: 0x00000A68
		[Address(RVA = "0x182E83260", Offset = "0x2E81860")]
		private void OnDestroy()
		{
		}

		// Token: 0x060002ED RID: 749 RVA: 0x0000286C File Offset: 0x00000A6C
		[Address(RVA = "0x180458550", Offset = "0x456B50")]
		public long GetCombinedNetworkId()
		{
		}

		// Token: 0x060002EE RID: 750 RVA: 0x00002870 File Offset: 0x00000A70
		[Address(RVA = "0x182E82FA0", Offset = "0x2E815A0")]
		public static bool HasEventTrigger(GameObject go)
		{
		}

		// Token: 0x060002EF RID: 751 RVA: 0x00002874 File Offset: 0x00000A74
		[Address(RVA = "0x18041E390", Offset = "0x41C990")]
		public bool IsReadyForEvents()
		{
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00002878 File Offset: 0x00000A78
		[Address(RVA = "0x182E82DC0", Offset = "0x2E813C0")]
		public void DeferEvent(VRC_EventHandler.VrcEvent e, VRC_EventHandler.VrcBroadcastType broadcast, GameObject instagator, float fastForward)
		{
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x0000287C File Offset: 0x00000A7C
		[Address(RVA = "0x182E83490", Offset = "0x2E81A90")]
		private IEnumerator ProcessDeferredEvents()
		{
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x00002880 File Offset: 0x00000A80
		[Address(RVA = "0x182E843B0", Offset = "0x2E829B0")]
		public VRC_EventHandler()
		{
		}

		// Token: 0x040003CC RID: 972
		[SerializeField]
		[FieldOffset(Offset = "0x18")]
		public List<VRC_EventHandler.VrcEvent> Events;

		// Token: 0x040003CD RID: 973
		[FieldOffset(Offset = "0x20")]
		private int <NetworkID>k__BackingField;

		// Token: 0x040003CE RID: 974
		[FieldOffset(Offset = "0x28")]
		private VRC_EventDispatcher _dispatcher;

		// Token: 0x040003CF RID: 975
		public static VRC_EventHandler.GetNetworkIdDelegate GetInstigatorId;

		// Token: 0x040003D0 RID: 976
		[FieldOffset(Offset = "0x8")]
		public static VRC_EventHandler.LogEventDelegate LogEvent;

		// Token: 0x040003D1 RID: 977
		[FieldOffset(Offset = "0x30")]
		public List<VRC_EventHandler.EventInfo> deferredEvents;

		// Token: 0x040003D2 RID: 978
		[FieldOffset(Offset = "0x38")]
		private Coroutine DeferredEventProcessor;
		*/

		public enum VrcEventType
		{
			MeshVisibility,
			AnimationFloat,
			AnimationBool,
			AnimationTrigger,
			AudioTrigger,
			PlayAnimation,
			SendMessage,
			SetParticlePlaying,
			TeleportPlayer,
			RunConsoleCommand,
			SetGameObjectActive,
			SetWebPanelURI,
			SetWebPanelVolume,
			SpawnObject,
			SendRPC,
			ActivateCustomTrigger,
			DestroyObject,
			SetLayer,
			SetMaterial,
			AddHealth,
			AddDamage,
			SetComponentActive,
			AnimationInt,
			AnimationIntAdd = 24,
			AnimationIntSubtract,
			AnimationIntMultiply,
			AnimationIntDivide,
			AddVelocity,
			SetVelocity,
			AddAngularVelocity,
			SetAngularVelocity,
			AddForce,
			SetUIText,
			CallUdonMethod
		}

		public enum VrcBroadcastType
		{
			Always,
			Master,
			Local,
			Owner,
			AlwaysUnbuffered,
			MasterUnbuffered,
			OwnerUnbuffered,
			AlwaysBufferOne,
			MasterBufferOne,
			OwnerBufferOne
		}

		public enum VrcTargetType
		{
			All,
			Others,
			Owner,
			Master,
			AllBuffered,
			OthersBuffered,
			Local,
			AllBufferOne,
			OthersBufferOne,
			TargetPlayer
		}

		public enum VrcBooleanOp
		{
			Unused = -1,
			False,
			True,
			Toggle
		}

		public class VrcEvent : IL2Base
		{
			public VrcEvent(IntPtr ptrNew) : base(ptrNew) =>
				ptr = ptrNew;

			public static IL2Method constructVrcEvent = null;
			public VrcEvent() : base(IntPtr.Zero)
			{
				if (constructVrcEvent == null)
				{
					constructVrcEvent = Instance_Class.GetMethod(".ctor");
					if (constructVrcEvent == null)
						return;
				}

				ptr = IL2Import.il2cpp_object_new(Instance_Class.ptr);
				constructVrcEvent.Invoke(ptr);
			}

			private static IL2Field fieldName = null;
			public string Name
			{
				get
				{
					if (!IL2Get.Field("Name", Instance_Class, ref fieldName))
						return null;

					return fieldName.GetValue(ptr)?.Unbox<string>();
				}
				set
				{
					if (!IL2Get.Field("Name", Instance_Class, ref fieldName))
						return;

					fieldName.SetValue(ptr, IL2Import.StringToIntPtr(value));
				}
			}

			public VrcEventType EventType;

			private static IL2Field fieldParameterString = null;
			public string ParameterString
			{
				get
				{
					if (!IL2Get.Field("ParameterString", Instance_Class, ref fieldParameterString))
						return null;

					return fieldParameterString.GetValue(ptr)?.Unbox<string>();
				}
				set
				{
					if (!IL2Get.Field("ParameterString", Instance_Class, ref fieldParameterString))
						return;

					fieldParameterString.SetValue(ptr, IL2Import.StringToIntPtr(value));
				}
			}

			public VrcBooleanOp ParameterBoolOp;

			public bool ParameterBool;

			public float ParameterFloat;

			public int ParameterInt;

			public GameObject ParameterObject;

			public GameObject[] ParameterObjects;

			public byte[] ParameterBytes;

			public int? ParameterBytesVersion;

			public bool TakeOwnershipOfTarget;

			public static IL2Type Instance_Class = VRC_EventHandler.Instance_Class.GetNestedType("VrcEvent");
		}

		/*
		public class EventInfo
		{
			public EventInfo()
			{
			}

			public VRC_EventHandler.VrcEvent evt;

			public VRC_EventHandler.VrcBroadcastType broadcast;

			public GameObject instagator;

			public float fastForward;
		}
		*/
		public static new IL2Type Instance_Class = Assemblies.a["VRCSDKBase"].GetClass("VRC_EventHandler", "VRC.SDKBase");
	}
}
