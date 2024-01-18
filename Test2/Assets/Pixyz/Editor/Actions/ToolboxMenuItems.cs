using UnityEditor;
namespace Pixyz.Toolbox.Editor {

	// THIS SCRIPT IS AUTOGENERATED. PLEASE DO NOT MODIFY OR MOVE IT.
	public static class ToolboxMenuItems {

		[MenuItem("Pixyz/Toolbox/Mesh/Decimate", priority = 22)]
		[MenuItem("GameObject/Pixyz/Mesh/Decimate", priority = -20)]
		public static void Adec551d1_048d_4e18_b55f_d69697513196() { Toolbox.RunToolboxAction(new Pixyz.Toolbox.Editor.DecimateAction()); }

		[MenuItem("Pixyz/Toolbox/Colliders/Create Collider", priority = 22)]
		[MenuItem("GameObject/Pixyz/Colliders/Create Collider", priority = -19)]
		public static void A8e2b34b9_e956_4376_9b39_2773d8c0a841() { Toolbox.RunToolboxAction(new Pixyz.Toolbox.Editor.CreateColliderAction()); }

		[MenuItem("Pixyz/Toolbox/Colliders/Remove Colliders", priority = 22)]
		[MenuItem("GameObject/Pixyz/Colliders/Remove Colliders", priority = -18)]
		public static void A6ca5a06b_a90b_4c0e_9712_a33bc1916526() { Toolbox.RunToolboxAction(new Pixyz.Toolbox.Editor.RemoveCollidersAction()); }

		[MenuItem("Pixyz/Toolbox/Mesh/Repair", priority = 22)]
		[MenuItem("GameObject/Pixyz/Mesh/Repair", priority = -17)]
		public static void Ac962f586_3079_4fc0_8733_574627a0f171() { Toolbox.RunToolboxAction(new Pixyz.Toolbox.Editor.RepairMeshAction()); }

		[MenuItem("Pixyz/Toolbox/Mesh/Remove Z-Fighting", priority = 22)]
		[MenuItem("GameObject/Pixyz/Mesh/Remove Z-Fighting", priority = -15)]
		public static void Ad45ca4fe_1471_47d9_bfbe_715eda7e8a06() { Toolbox.RunToolboxAction(new Pixyz.Toolbox.Editor.RemoveZFightingAction()); }

		[MenuItem("Pixyz/Toolbox/Mesh/Remove Hidden", priority = 22)]
		[MenuItem("GameObject/Pixyz/Mesh/Remove Hidden", priority = -14)]
		public static void Af54a67c7_b5b4_43f1_a42f_fe3204246db2() { Toolbox.RunToolboxAction(new Pixyz.Toolbox.Editor.RemoveHiddenAction()); }

		[MenuItem("Pixyz/Toolbox/Remeshing/Retopologize", priority = 22)]
		[MenuItem("GameObject/Pixyz/Remeshing/Retopologize", priority = -13)]
		public static void A8ff9de89_a30f_4863_bb3c_f759d0e8681d() { Toolbox.RunToolboxAction(new Pixyz.Toolbox.Editor.RetopologizeAction()); }

		[MenuItem("Pixyz/Toolbox/Remeshing/Create Impostor", priority = 22)]
		[MenuItem("GameObject/Pixyz/Remeshing/Create Impostor", priority = -12)]
		public static void A64a5654c_5cc7_4c61_bd58_60e339e5cceb() { Toolbox.RunToolboxAction(new Pixyz.Toolbox.Editor.BakeImpostor()); }

		[MenuItem("Pixyz/Toolbox/Remeshing/Create Billboard", priority = 22)]
		[MenuItem("GameObject/Pixyz/Remeshing/Create Billboard", priority = -12)]
		public static void Ab68e59ea_04af_4710_a348_0d5857e0f284() { Toolbox.RunToolboxAction(new Pixyz.Toolbox.Editor.GenerateBillboardAction()); }

		[MenuItem("Pixyz/Toolbox/Hierarchy/Merge", priority = 22)]
		[MenuItem("GameObject/Pixyz/Hierarchy/Merge", priority = -11)]
		public static void A3d41a3c8_3eae_47a7_887e_802820219987() { Toolbox.RunToolboxAction(new Pixyz.Toolbox.Editor.Merge()); }

		[MenuItem("Pixyz/Toolbox/Hierarchy/Combine", priority = 22)]
		[MenuItem("GameObject/Pixyz/Hierarchy/Combine", priority = -10)]
		public static void A7dc11a4c_b704_4dc1_81c6_f596cb1638d5() { Toolbox.RunToolboxAction(new Pixyz.Toolbox.Editor.CombineAction()); }

		[MenuItem("Pixyz/Toolbox/Hierarchy/Replace by...", priority = 22)]
		[MenuItem("GameObject/Pixyz/Hierarchy/Replace by...", priority = -9)]
		public static void A1257398c_1af4_48bb_8317_4de2ae7072b4() { Toolbox.RunToolboxAction(new Pixyz.Toolbox.Editor.ReplaceBy()); }

		[MenuItem("Pixyz/Toolbox/Hierarchy/Explode", priority = 22)]
		[MenuItem("GameObject/Pixyz/Hierarchy/Explode", priority = -8)]
		public static void Abef6895a_3ed8_4e1e_86b3_e8cc89438bb3() { Toolbox.RunToolboxAction(new Pixyz.Toolbox.Editor.ExplodeSubmeshesAction()); }

		[MenuItem("Pixyz/Toolbox/Pivot/Move Pivot", priority = 22)]
		[MenuItem("GameObject/Pixyz/Pivot/Move Pivot", priority = -7)]
		public static void Aadd39463_e62a_4a4b_8ac3_1dd6809fe008() { Toolbox.RunToolboxAction(new Pixyz.Toolbox.Editor.MovePivotAction()); }

		[MenuItem("Pixyz/Toolbox/Normals/Flip Normals", priority = 22)]
		[MenuItem("GameObject/Pixyz/Normals/Flip Normals", priority = -6)]
		public static void A0b278f48_6d57_4804_a7fa_4e0906515bc8() { Toolbox.RunToolboxAction(new Pixyz.Toolbox.Editor.FlipNormals()); }

		[MenuItem("Pixyz/Toolbox/Normals/Create Normals", priority = 22)]
		[MenuItem("GameObject/Pixyz/Normals/Create Normals", priority = -5)]
		public static void Ad00036d3_83cb_4104_a725_599e4d23a2df() { Toolbox.RunToolboxAction(new Pixyz.Toolbox.Editor.CreateNormals()); }

		[MenuItem("Pixyz/Toolbox/UVs/Create UVs", priority = 22)]
		[MenuItem("GameObject/Pixyz/UVs/Create UVs", priority = -4)]
		public static void Aff72d9fa_1800_4e20_95dc_04987c2a2924() { Toolbox.RunToolboxAction(new Pixyz.Toolbox.Editor.CreateUVs()); }

		[MenuItem("Pixyz/Toolbox/UVs/Create UVs for Lightmaps", priority = 22)]
		[MenuItem("GameObject/Pixyz/UVs/Create UVs for Lightmaps", priority = -3)]
		public static void A02d19ea0_234f_4770_aa3e_b8f6b843eecd() { Toolbox.RunToolboxAction(new Pixyz.Toolbox.Editor.CreateLightmapUVs()); }

	}
}