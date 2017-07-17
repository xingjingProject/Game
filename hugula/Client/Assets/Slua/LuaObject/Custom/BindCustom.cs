﻿using System;
using System.Collections.Generic;
namespace SLua {
	[LuaBinder(3)]
	public class BindCustom {
		public static Action<IntPtr>[] GetBindList() {
			Action<IntPtr>[] list= {
				Lua_Hugula_HugulaSetting.reg,
				Lua_Hugula_CodeVersion.reg,
				Lua_Hugula_Cryptograph_CryptographHelper.reg,
				Lua_Hugula_Cryptograph_DESHelper.reg,
				Lua_Hugula_Loader_ABDelayUnloadManager.reg,
				Lua_Hugula_Loader_CCar.reg,
				Lua_Hugula_Loader_CRequest.reg,
				Lua_Hugula_Loader_CResLoader.reg,
				Lua_Hugula_Loader_LoadingEventArg.reg,
				Lua_Hugula_Loader_CacheManager.reg,
				Lua_Hugula_Loader_CountMananger.reg,
				Lua_Hugula_Loader_GroupRequestRecord.reg,
				Lua_Hugula_Loader_LRequest.reg,
				Lua_Hugula_Loader_LResLoader.reg,
				Lua_Hugula_Loader_UriGroup.reg,
				Lua_Hugula_Net_LNet.reg,
				Lua_Hugula_Net_Msg.reg,
				Lua_Hugula_BytesAsset.reg,
				Lua_Hugula_PLua.reg,
				Lua_Hugula_Pool_PrefabPool.reg,
				Lua_Hugula_ReferGameObjects.reg,
				Lua_Hugula_Update_CrcCheck.reg,
				Lua_Hugula_Update_Download.reg,
				Lua_Hugula_Utils_CUtils.reg,
				Lua_Hugula_Utils_Common.reg,
				Lua_Hugula_Utils_FileHelper.reg,
				Lua_Hugula_Utils_LightHelper.reg,
				Lua_Hugula_Utils_LuaHelper.reg,
				Lua_AnimationDirection.reg,
				Lua_AssetBundleScene.reg,
				Lua_Hugula_Utils_ZipHelper.reg,
				Lua_Hugula_Localization.reg,
				Lua_Hugula_UGUILocalize.reg,
				Lua_Hugula_UGUIExtend_ScrollRectItem.reg,
				Lua_Hugula_UGUIExtend_ScrollRectTable.reg,
				Lua_Hugula_UGUIExtend_CEventReceive.reg,
				Lua_Hugula_UGUIExtend_UGUIEvent.reg,
				Lua_Hugula_UGUIExtend_UIEventLuaTrigger.reg,
				Lua_UIJoint.reg,
				Lua_UIParentJoint.reg,
				Lua_LTDescr.reg,
				Lua_LTDescrOptional.reg,
				Lua_LeanAudioStream.reg,
				Lua_LeanAudio.reg,
				Lua_LeanAudioOptions.reg,
				Lua_TweenAction.reg,
				Lua_LeanTweenType.reg,
				Lua_LeanTween.reg,
				Lua_LTUtility.reg,
				Lua_LTBezier.reg,
				Lua_LTBezierPath.reg,
				Lua_LTSpline.reg,
				Lua_LTRect.reg,
				Lua_LTEvent.reg,
				Lua_LTGUI.reg,
				Lua_System_Collections_Generic_List_1_int.reg,
				Lua_System_Collections_Generic_Dictionary_2_int_string.reg,
				Lua_System_String.reg,
			};
			return list;
		}
	}
}
