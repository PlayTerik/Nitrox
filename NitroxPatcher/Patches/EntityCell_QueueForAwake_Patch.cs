﻿using Harmony;
using System;
using System.Reflection;
using System.Collections.Generic;
using NitroxClient.MonoBehaviours;

namespace NitroxPatcher.Patches
{
    public class EntityCell_QueueForAwake_Patch : NitroxPatch
    {
        public static readonly Type TARGET_CLASS = typeof(EntityCell);
        public static readonly MethodInfo TARGET_METHOD = TARGET_CLASS.GetMethod("QueueForAwake");
        
        public static bool Prefix(EntityCell __instance)
        {
            Multiplayer.Logic.Chunks.ChunkLoaded(__instance.BatchId, __instance.Level);

            return true;
        }

        public override void Patch(HarmonyInstance harmony)
        {
            this.PatchPrefix(harmony, TARGET_METHOD);
        }
    }
}
