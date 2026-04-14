#pragma once
#include "pch.h"
#include "Utilities/ISerializable.h"
#include "Utilities/Audio/blip_buf.h"
#include "Utilities/Audio/StereoDelayFilter.h"
#include "Utilities/Audio/StereoPanningFilter.h"
#include "Utilities/Audio/StereoCombFilter.h"
#include "NesTypes.h"

class NesConsole;
class SoundMixer;
class EmuSettings;
enum class ConsoleRegion;

class NesSoundMixer : public ISerializable
{
public:
	static constexpr uint32_t CycleLength = 10000;
	static constexpr uint32_t BitsPerSample = 16;

private:
	static constexpr uint32_t MaxSampleRate = 96000;
	static constexpr uint32_t MaxSamplesPerFrame = MaxSampleRate / 60 * 4 * 2; //x4 to allow CPU overclocking up to 10x, x2 for panning stereo
	static constexpr uint32_t MaxChannelCount = 11;
	static constexpr double squareSumFactor[31] = { 1.0, 1.359063, 1.349176, 1.339432, 1.329828, 1.320361, 1.311028, 1.301826, 1.292751, 1.283803, 1.274978, 1.266273, 1.257686, 1.249215, 1.240857, 1.232610, 1.224472, 1.216441, 1.208515, 1.200691, 1.192968, 1.185344, 1.177816, 1.170383, 1.163044, 1.155796, 1.148638, 1.141568, 1.134584, 1.127686, 1.120871 };

	NesConsole* _console = nullptr;
	SoundMixer* _mixer = nullptr;

	StereoPanningFilter _stereoPanning;
	StereoDelayFilter _stereoDelay;
	StereoCombFilter _stereoCombFilter;

	int16_t _previousOutputLeft = 0;
	int16_t _previousOutputRight = 0;

	vector<uint32_t> _timestamps;
	int16_t _channelOutput[MaxChannelCount][CycleLength] = {};
	int16_t _currentOutput[MaxChannelCount] = {};
	uint8_t _squareVolume[2] = {};

	blip_t* _blipBufLeft = nullptr;
	blip_t* _blipBufRight = nullptr;
	int16_t* _outputBuffer = nullptr;
	size_t _sampleCount = 0;
	double _volumes[MaxChannelCount] = {};
	double _panning[MaxChannelCount] = {};

	uint32_t _sampleRate = 0;
	uint32_t _clockRate = 0;

	bool _hasPanning = false;

	__forceinline double GetChannelOutput(AudioChannel channel, bool forRightChannel);
	__forceinline int16_t GetOutputVolume(bool forRightChannel);
	void EndFrame(uint32_t time);

	void ProcessVsDualSystemAudio();

	void UpdateRates(bool forceUpdate);
	
public:
	NesSoundMixer(NesConsole* console);
	virtual ~NesSoundMixer();

	void SetRegion(ConsoleRegion region);
	void Reset();

	void PlayAudioBuffer(uint32_t cycle);
	void AddDelta(AudioChannel channel, uint32_t time, int16_t delta);
	void RawVolume(AudioChannel channel, uint8_t rawVolume);

	void Serialize(Serializer& s) override;
};