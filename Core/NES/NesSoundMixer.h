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
	static constexpr double squareSumFactor[31] = { 1.0, 1.358399, 1.347869, 1.337501, 1.327291, 1.317235, 1.307331, 1.297575, 1.287964, 1.278493, 1.269161, 1.259964, 1.250900, 1.241965, 1.233157, 1.224472, 1.215909, 1.207466, 1.199138, 1.190925, 1.182824, 1.174832, 1.166947, 1.159167, 1.151490, 1.143915, 1.136438, 1.129059, 1.121775, 1.114584, 1.107484 };

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
