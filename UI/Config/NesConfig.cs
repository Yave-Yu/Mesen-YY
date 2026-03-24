using Mesen.Interop;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Mesen.Config
{
	public class NesConfig : BaseConfig<NesConfig>
	{
		[Reactive] public ConsoleOverrideConfig ConfigOverrides { get; set; } = new();

		//Input
		[Reactive] public NesControllerConfig Port1 { get; set; } = new();
		[Reactive] public NesControllerConfig Port2 { get; set; } = new();
		[Reactive] public NesControllerConfig ExpPort { get; set; } = new();

		[Reactive] public NesControllerConfig Port1A { get; set; } = new();
		[Reactive] public NesControllerConfig Port1B { get; set; } = new();
		[Reactive] public NesControllerConfig Port1C { get; set; } = new();
		[Reactive] public NesControllerConfig Port1D { get; set; } = new();

		[Reactive] public NesControllerConfig ExpPortA { get; set; } = new();
		[Reactive] public NesControllerConfig ExpPortB { get; set; } = new();
		[Reactive] public NesControllerConfig ExpPortC { get; set; } = new();
		[Reactive] public NesControllerConfig ExpPortD { get; set; } = new();
		
		[Reactive] public NesControllerConfig MapperInput { get; set; } = new();

		[Reactive][MinMax(0, 3)] public UInt32 LightDetectionRadius { get; set; } = 0;
		[Reactive] public bool AutoConfigureInput { get; set; } = true;

		//General
		[ValidValues(ConsoleRegion.Auto, ConsoleRegion.Ntsc, ConsoleRegion.Pal, ConsoleRegion.Dendy)]
		[Reactive] public ConsoleRegion Region { get; set; } = ConsoleRegion.Auto;

		[Reactive] public bool EnableHdPacks { get; set; } = true;
		[Reactive] public bool DisableGameDatabase { get; set; } = false;
		[Reactive] public bool FdsAutoLoadDisk { get; set; } = true;
		[Reactive] public bool FdsFastForwardOnLoad { get; set; } = false;
		[Reactive] public bool FdsAutoInsertDisk { get; set; } = false;
		[Reactive] public VsDualOutputOption VsDualVideoOutput { get; set; } = VsDualOutputOption.Both;
		[Reactive] public VsDualOutputOption VsDualAudioOutput { get; set; } = VsDualOutputOption.Both;

		//Video
		[Reactive] public bool DisableSprites { get; set; } = false;
		[Reactive] public bool DisableBackground { get; set; } = false;
		[Reactive] public bool ForceBackgroundFirstColumn { get; set; } = false;
		[Reactive] public bool ForceSpritesFirstColumn { get; set; } = false;
		[Reactive] public bool RemoveSpriteLimit { get; set; } = false;
		[Reactive] public bool AdaptiveSpriteLimit { get; set; } = false;
		[Reactive] public bool EnablePalBorders { get; set; } = false;

		[Reactive] public bool UseCustomVsPalette { get; set; } = false;

		[Reactive] public OverscanConfig NtscOverscan { get; set; } = new();
		[Reactive] public OverscanConfig PalOverscan { get; set; } = new();
		
		//Emulation
		[Reactive] public bool EnableOamDecay { get; set; } = false;
		[Reactive] public bool EnablePpuOamRowCorruption { get; set; } = false;
		[Reactive] public bool EnablePpuSpriteEvalBug { get; set; } = false;
		[Reactive] public bool DisableOamAddrBug { get; set; } = false;
		[Reactive] public bool DisablePaletteRead { get; set; } = false;
		[Reactive] public bool DisablePpu2004Reads { get; set; } = false;
		[Reactive] public bool EnablePpu2000ScrollGlitch { get; set; } = false;
		[Reactive] public bool EnablePpu2006ScrollGlitch { get; set; } = false;
		[Reactive] public bool RestrictPpuAccessOnFirstFrame { get; set; } = false;
		[Reactive] public bool EnableDmcSampleDuplicationGlitch { get; set; } = false;
		[Reactive] public bool EnableCpuTestMode { get; set; } = false;
		
		[Reactive] public NesConsoleType ConsoleType { get; set; } = NesConsoleType.Nes001;
		[Reactive] public bool DisablePpuReset { get; set; } = false;
		[Reactive] public bool AllowInvalidInput { get; set; } = false;
		[Reactive] public bool DisableGameGenieBusConflicts { get; set; } = false;
		[Reactive] public bool DisableFlashSaves { get; set; } = false;
		[Reactive] public bool OverwriteOriginalRom { get; set; } = false;

		[Reactive] public bool RandomizeMapperPowerOnState { get; set; } = false;
		[Reactive] public bool RandomizeCpuPpuAlignment { get; set; } = false;
		[Reactive] public RamState RamPowerOnState { get; set; } = RamState.Random;

		[Reactive] [MinMax(0, 1000)] public UInt32 PpuExtraScanlinesBeforeNmi { get; set; } = 0;
		[Reactive] [MinMax(0, 1000)] public UInt32 PpuExtraScanlinesAfterNmi { get; set; } = 0;

		//Audio
		
		[Reactive] public bool ReduceDmcPopping { get; set; } = false;
		[Reactive] public bool SilenceTriangleHighFreq { get; set; } = false;
		[Reactive] public bool UseLinearSquareMixer { get; set; } = false;
		[Reactive] public bool DisableNoiseModeFlag { get; set; } = false;
		[Reactive] public bool DisableSquareResetPhase { get; set; } = false;
		[Reactive] public bool SwapDutyCycles { get; set; } = false;
		[Reactive] public bool ReverseDpcmBitOrder { get; set; } = false;

		[Reactive] [MinMax(0, 100)] public UInt32 Square1Volume { get; set; } = 100;
		[Reactive] [MinMax(0, 100)] public UInt32 Square2Volume { get; set; } = 100;
		[Reactive] [MinMax(0, 100)] public UInt32 TriangleVolume { get; set; } = 90;
		[Reactive] [MinMax(0, 100)] public UInt32 NoiseVolume { get; set; } = 100;
		[Reactive] [MinMax(0, 100)] public UInt32 DmcVolume { get; set; } = 100;
		[Reactive] [MinMax(0, 100)] public UInt32 FdsVolume { get; set; } = 100;
		[Reactive] [MinMax(0, 100)] public UInt32 Mmc5Volume { get; set; } = 100;
		[Reactive] [MinMax(0, 100)] public UInt32 Vrc6Volume { get; set; } = 100;
		[Reactive] [MinMax(0, 100)] public UInt32 Vrc7Volume { get; set; } = 100;
		[Reactive] [MinMax(0, 100)] public UInt32 Namco163Volume { get; set; } = 100;
		[Reactive] [MinMax(0, 100)] public UInt32 Sunsoft5bVolume { get; set; } = 100;
		[Reactive] [MinMax(0, 100)] public UInt32 EpsmVolume { get; set; } = 100;

		[Reactive] [MinMax(-100, 100)] public Int32 Square1Panning { get; set; } = 0;
		[Reactive] [MinMax(-100, 100)] public Int32 Square2Panning { get; set; } = 0;
		[Reactive] [MinMax(-100, 100)] public Int32 TrianglePanning { get; set; } = 0;
		[Reactive] [MinMax(-100, 100)] public Int32 NoisePanning { get; set; } = 0;
		[Reactive] [MinMax(-100, 100)] public Int32 DmcPanning { get; set; } = 0;
		[Reactive] [MinMax(-100, 100)] public Int32 FdsPanning { get; set; } = 0;
		[Reactive] [MinMax(-100, 100)] public Int32 Mmc5Panning { get; set; } = 0;
		[Reactive] [MinMax(-100, 100)] public Int32 Vrc6Panning { get; set; } = 0;
		[Reactive] [MinMax(-100, 100)] public Int32 Vrc7Panning { get; set; } = 0;
		[Reactive] [MinMax(-100, 100)] public Int32 Namco163Panning { get; set; } = 0;
		[Reactive] [MinMax(-100, 100)] public Int32 Sunsoft5bPanning { get; set; } = 0;

		[Reactive] public StereoFilter StereoFilter { get; set; } = StereoFilter.None;
		[Reactive] [MinMax(0, 100)] public Int32 StereoDelay { get; set; } = 15;
		[Reactive] [MinMax(-180, 180)] public Int32 StereoPanningAngle { get; set; } = 15;
		[Reactive] [MinMax(1, 100)] public Int32 StereoCombFilterDelay { get; set; } = 5;
		[Reactive] [MinMax(1, 200)] public Int32 StereoCombFilterStrength { get; set; } = 100;

		//Misc
		[Reactive] public bool BreakOnCrash { get; set; } = false;

		[Reactive] public Int32 InputScanline { get; set; } = 241;
		[Reactive] public UInt32[] UserPalette { get; set; } = new UInt32[64] { 0xFF737373, 0xFF00219C, 0xFF2100A5, 0xFF420084, 0xFF5A0063, 0xFF630021, 0xFF631000, 0xFF522100, 0xFF313900, 0xFF104200, 0xFF004A00, 0xFF004A21, 0xFF003963, 0xFF000000, 0xFF000000, 0xFF000000, 0xFFB5B5B5, 0xFF0063E7, 0xFF3142F7, 0xFF7300E7, 0xFFA500B5, 0xFFC60063, 0xFFC62100, 0xFF9C5200, 0xFF737300, 0xFF318400, 0xFF008C00, 0xFF008C42, 0xFF007B9C, 0xFF000000, 0xFF000000, 0xFF000000, 0xFFFFFFFF, 0xFF5AADFF, 0xFF7B94FF, 0xFFB57BFF, 0xFFEF5AFF, 0xFFFF63BD, 0xFFFF846B, 0xFFEFA500, 0xFFCEC600, 0xFF73DE00, 0xFF21E700, 0xFF00E773, 0xFF00D6E7, 0xFF525252, 0xFF000000, 0xFF000000, 0xFFFFFFFF, 0xFFADDEFF, 0xFFBDCEFF, 0xFFDEBDFF, 0xFFF7B5FF, 0xFFFFB5E7, 0xFFFFC6B5, 0xFFF7D6A5, 0xFFEFE794, 0xFFC6F794, 0xFFA5FFA5, 0xFF94FFB5, 0xFF84F7FF, 0xFFC6C6C6, 0xFF000000, 0xFF000000 };

		public void ApplyConfig()
		{
			ConfigManager.Config.Video.ApplyConfig();

			UInt32[] palette = new UInt32[512];
			Array.Copy(UserPalette, palette, UserPalette.Length);
			bool isFullPalette = UserPalette.Length == 512;

			ConfigApi.SetNesConfig(new InteropNesConfig() {
				Port1 = Port1.ToInterop(),
				Port1A = Port1A.ToInterop(),
				Port1B = Port1B.ToInterop(),
				Port1C = Port1C.ToInterop(),
				Port1D = Port1D.ToInterop(),

				Port2 = Port2.ToInterop(),
				
				ExpPort = ExpPort.ToInterop(),
				ExpPortA = ExpPortA.ToInterop(),
				ExpPortB = ExpPortB.ToInterop(),
				ExpPortC = ExpPortC.ToInterop(),
				ExpPortD = ExpPortD.ToInterop(),
				
				MapperInput = MapperInput.ToInterop(),

				LightDetectionRadius = LightDetectionRadius,
				AutoConfigureInput = AutoConfigureInput,

				Region = Region,
				EnableHdPacks = EnableHdPacks,
				DisableGameDatabase = DisableGameDatabase,
				FdsAutoLoadDisk = FdsAutoLoadDisk,
				FdsFastForwardOnLoad = FdsFastForwardOnLoad,
				FdsAutoInsertDisk = FdsAutoInsertDisk,
				VsDualVideoOutput = VsDualVideoOutput,
				VsDualAudioOutput = VsDualAudioOutput,

				SpritesEnabled = !DisableSprites,
				BackgroundEnabled = !DisableBackground,
				ForceBackgroundFirstColumn = ForceBackgroundFirstColumn,
				ForceSpritesFirstColumn = ForceSpritesFirstColumn,
				RemoveSpriteLimit = RemoveSpriteLimit,
				AdaptiveSpriteLimit = AdaptiveSpriteLimit,
				EnablePalBorders = EnablePalBorders,

				UseCustomVsPalette = UseCustomVsPalette,

				NtscOverscan = NtscOverscan.ToInterop(),
				PalOverscan = PalOverscan.ToInterop(),

				ConsoleType = ConsoleType,
				DisablePpuReset = DisablePpuReset,
				AllowInvalidInput = AllowInvalidInput,
				DisableGameGenieBusConflicts = DisableGameGenieBusConflicts,
				DisableFlashSaves = DisableFlashSaves,
				OverwriteOriginalRom = OverwriteOriginalRom,

				EnableOamDecay = EnableOamDecay,
				EnablePpuOamRowCorruption = EnablePpuOamRowCorruption,
				EnablePpuSpriteEvalBug = EnablePpuSpriteEvalBug,
				DisableOamAddrBug = DisableOamAddrBug,
				DisablePaletteRead = DisablePaletteRead,
				DisablePpu2004Reads = DisablePpu2004Reads,
				EnablePpu2000ScrollGlitch = EnablePpu2000ScrollGlitch,
				EnablePpu2006ScrollGlitch = EnablePpu2006ScrollGlitch,
				RestrictPpuAccessOnFirstFrame = RestrictPpuAccessOnFirstFrame,
				EnableDmcSampleDuplicationGlitch = EnableDmcSampleDuplicationGlitch,
				EnableCpuTestMode = EnableCpuTestMode,

				RandomizeMapperPowerOnState = RandomizeMapperPowerOnState,
				RandomizeCpuPpuAlignment = RandomizeCpuPpuAlignment,
				RamPowerOnState = RamPowerOnState,

				PpuExtraScanlinesAfterNmi = PpuExtraScanlinesAfterNmi,
				PpuExtraScanlinesBeforeNmi = PpuExtraScanlinesBeforeNmi,

				ReduceDmcPopping = ReduceDmcPopping,
				SilenceTriangleHighFreq = SilenceTriangleHighFreq,
				UseLinearSquareMixer = UseLinearSquareMixer,
				DisableNoiseModeFlag = DisableNoiseModeFlag,
				DisableSquareResetPhase = DisableSquareResetPhase,
				SwapDutyCycles = SwapDutyCycles,
				ReverseDpcmBitOrder = ReverseDpcmBitOrder,

				Square1Volume = Square1Volume,
				Square2Volume = Square2Volume,
				TriangleVolume = TriangleVolume,
				NoiseVolume = NoiseVolume,
				DmcVolume = DmcVolume,
				FdsVolume = FdsVolume,
				Mmc5Volume = Mmc5Volume,
				Vrc6Volume = Vrc6Volume,
				Vrc7Volume = Vrc7Volume,
				Namco163Volume = Namco163Volume,
				Sunsoft5bVolume = Sunsoft5bVolume,
				EpsmVolume = EpsmVolume,
				Square1Panning = Square1Panning,
				Square2Panning = Square2Panning,
				TrianglePanning = TrianglePanning,
				NoisePanning = NoisePanning,
				DmcPanning = DmcPanning,
				FdsPanning = FdsPanning,
				Mmc5Panning = Mmc5Panning,
				Vrc6Panning = Vrc6Panning,
				Vrc7Panning = Vrc7Panning,
				Namco163Panning = Namco163Panning,
				Sunsoft5bPanning = Sunsoft5bPanning,

				StereoFilter = StereoFilter,
				StereoDelay = StereoDelay,
				StereoPanningAngle = StereoPanningAngle,
				StereoCombFilterDelay = StereoCombFilterDelay,
				StereoCombFilterStrength = StereoCombFilterStrength,

				BreakOnCrash = BreakOnCrash,

				InputScanline = InputScanline,

				IsFullColorPalette = isFullPalette,
				UserPalette = palette,
			});
		}

		public void InitializeDefaults(DefaultKeyMappingType defaultMappings)
		{
			Port1.InitDefaults<NesKeyMapping>(defaultMappings, ControllerType.NesController);
		}

		public void UpdateInputFromCoreConfig()
		{
			//Used to update input devices when the core requests changes
			InteropNesConfig cfg = ConfigApi.GetNesConfig();
			Port1.Type = cfg.Port1.Type;
			Port1A.Type = cfg.Port1A.Type;
			Port1B.Type = cfg.Port1B.Type;
			Port1C.Type = cfg.Port1C.Type;
			Port1D.Type = cfg.Port1D.Type;
			Port2.Type = cfg.Port2.Type;
			ExpPort.Type = cfg.ExpPort.Type;
			ExpPortA.Type = cfg.ExpPortA.Type;
			ExpPortB.Type = cfg.ExpPortB.Type;
			ApplyConfig();
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct InteropNesConfig
	{
		public InteropControllerConfig Port1;
		public InteropControllerConfig Port2;
		public InteropControllerConfig ExpPort;

		public InteropControllerConfig Port1A;
		public InteropControllerConfig Port1B;
		public InteropControllerConfig Port1C;
		public InteropControllerConfig Port1D;

		public InteropControllerConfig ExpPortA;
		public InteropControllerConfig ExpPortB;
		public InteropControllerConfig ExpPortC;
		public InteropControllerConfig ExpPortD;

		public InteropControllerConfig MapperInput;

		public UInt32 LightDetectionRadius;
		[MarshalAs(UnmanagedType.I1)] public bool AutoConfigureInput;

		public ConsoleRegion Region;
		[MarshalAs(UnmanagedType.I1)] public bool EnableHdPacks;
		[MarshalAs(UnmanagedType.I1)] public bool DisableGameDatabase;
		[MarshalAs(UnmanagedType.I1)] public bool FdsAutoLoadDisk;
		[MarshalAs(UnmanagedType.I1)] public bool FdsFastForwardOnLoad;
		[MarshalAs(UnmanagedType.I1)] public bool FdsAutoInsertDisk;
		public VsDualOutputOption VsDualVideoOutput;
		public VsDualOutputOption VsDualAudioOutput;

		[MarshalAs(UnmanagedType.I1)] public bool SpritesEnabled;
		[MarshalAs(UnmanagedType.I1)] public bool BackgroundEnabled;
		[MarshalAs(UnmanagedType.I1)] public bool ForceBackgroundFirstColumn;
		[MarshalAs(UnmanagedType.I1)] public bool ForceSpritesFirstColumn;
		[MarshalAs(UnmanagedType.I1)] public bool RemoveSpriteLimit;
		[MarshalAs(UnmanagedType.I1)] public bool AdaptiveSpriteLimit;
		[MarshalAs(UnmanagedType.I1)] public bool EnablePalBorders;
		
		[MarshalAs(UnmanagedType.I1)] public bool UseCustomVsPalette;

		public InteropOverscanDimensions NtscOverscan;
		public InteropOverscanDimensions PalOverscan;

		public NesConsoleType ConsoleType;
		[MarshalAs(UnmanagedType.I1)] public bool DisablePpuReset;
		[MarshalAs(UnmanagedType.I1)] public bool AllowInvalidInput;
		[MarshalAs(UnmanagedType.I1)] public bool DisableGameGenieBusConflicts;
		[MarshalAs(UnmanagedType.I1)] public bool DisableFlashSaves;
		[MarshalAs(UnmanagedType.I1)] public bool OverwriteOriginalRom;

		[MarshalAs(UnmanagedType.I1)] public bool EnableOamDecay;
		[MarshalAs(UnmanagedType.I1)] public bool EnablePpuOamRowCorruption;
		[MarshalAs(UnmanagedType.I1)] public bool EnablePpuSpriteEvalBug;
		[MarshalAs(UnmanagedType.I1)] public bool DisableOamAddrBug;
		[MarshalAs(UnmanagedType.I1)] public bool DisablePaletteRead;
		[MarshalAs(UnmanagedType.I1)] public bool DisablePpu2004Reads;
		[MarshalAs(UnmanagedType.I1)] public bool EnablePpu2000ScrollGlitch;
		[MarshalAs(UnmanagedType.I1)] public bool EnablePpu2006ScrollGlitch;
		[MarshalAs(UnmanagedType.I1)] public bool RestrictPpuAccessOnFirstFrame;
		[MarshalAs(UnmanagedType.I1)] public bool EnableDmcSampleDuplicationGlitch;
		[MarshalAs(UnmanagedType.I1)] public bool EnableCpuTestMode;

		[MarshalAs(UnmanagedType.I1)] public bool RandomizeMapperPowerOnState;
		[MarshalAs(UnmanagedType.I1)] public bool RandomizeCpuPpuAlignment;
		public RamState RamPowerOnState;

		public UInt32 PpuExtraScanlinesBeforeNmi;
		public UInt32 PpuExtraScanlinesAfterNmi;

		[MarshalAs(UnmanagedType.I1)] public bool ReduceDmcPopping;
		[MarshalAs(UnmanagedType.I1)] public bool SilenceTriangleHighFreq;
		[MarshalAs(UnmanagedType.I1)] public bool UseLinearSquareMixer;
		[MarshalAs(UnmanagedType.I1)] public bool DisableNoiseModeFlag;
		[MarshalAs(UnmanagedType.I1)] public bool DisableSquareResetPhase;
		[MarshalAs(UnmanagedType.I1)] public bool SwapDutyCycles;
		[MarshalAs(UnmanagedType.I1)] public bool ReverseDpcmBitOrder;

		[MarshalAs(UnmanagedType.I1)] public bool BreakOnCrash;

		public Int32 InputScanline;

		[MarshalAs(UnmanagedType.I1)] public bool IsFullColorPalette;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
		public UInt32[] UserPalette;

		public UInt32 Square1Volume;
		public UInt32 Square2Volume;
		public UInt32 TriangleVolume;
		public UInt32 NoiseVolume;
		public UInt32 DmcVolume;
		public UInt32 FdsVolume;
		public UInt32 Mmc5Volume;
		public UInt32 Vrc6Volume;
		public UInt32 Vrc7Volume;
		public UInt32 Namco163Volume;
		public UInt32 Sunsoft5bVolume;
		public UInt32 EpsmVolume;

		public Int32 Square1Panning;
		public Int32 Square2Panning;
		public Int32 TrianglePanning;
		public Int32 NoisePanning;
		public Int32 DmcPanning;
		public Int32 FdsPanning;
		public Int32 Mmc5Panning;
		public Int32 Vrc6Panning;
		public Int32 Vrc7Panning;
		public Int32 Namco163Panning;
		public Int32 Sunsoft5bPanning;

		public StereoFilter StereoFilter;
		public Int32 StereoDelay;
		public Int32 StereoPanningAngle;
		public Int32 StereoCombFilterDelay;
		public Int32 StereoCombFilterStrength;
	}

	public enum StereoFilter
	{
		None = 0,
		Delay = 1,
		Panning = 2,
		CombFilter = 3,
	}

	public enum VsDualOutputOption
	{
		Both = 0,
		MainSystemOnly = 1,
		SubSystemOnly = 2
	}

	public enum NesConsoleType
	{
		Nes001,
		Nes101,
		Hvc001,
		Hvc101
	}
}
