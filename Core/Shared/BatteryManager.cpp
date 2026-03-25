#include "pch.h"
#include "Shared/BatteryManager.h"
#include "Shared/Emulator.h"
#include "Utilities/VirtualFile.h"
#include "Utilities/FolderUtilities.h"
#include "Utilities/StringUtilities.h"

void BatteryManager::Initialize(string romName, Emulator *emu, bool setBatteryFlag)
{
	_romName = romName;
	_emu = emu;
	_hasBattery = setBatteryFlag;
}

string BatteryManager::GetConsoleName()
{
	switch(_emu->GetConsoleType()) {
		case ConsoleType::Nes:
			return "NES";
		case ConsoleType::Snes:
			return "SNES";
		case ConsoleType::Gameboy:
			return "Gameboy";
		case ConsoleType::Gba:
			return "GBA";
		case ConsoleType::PcEngine:
			return "PCE";
		case ConsoleType::Sms:
			return "SMS";
		case ConsoleType::Ws:
			return "WS";
		default:
			return "CV";
	}
}

string BatteryManager::GetBasePath(string& extension)
{
	if(StringUtilities::StartsWith(extension, ".")) {
		return FolderUtilities::CombinePath(FolderUtilities::GetSaveFolder(GetConsoleName()), _romName + extension);
	} else {
		return FolderUtilities::CombinePath(FolderUtilities::GetSaveFolder(GetConsoleName()), extension);
	}
}

void BatteryManager::SetBatteryProvider(shared_ptr<IBatteryProvider> provider)
{
	_provider = provider;
}

void BatteryManager::SetBatteryRecorder(shared_ptr<IBatteryRecorder> recorder)
{
	_recorder = recorder;
}

void BatteryManager::SaveBattery(string extension, uint8_t* data, uint32_t length)
{
	if(_romName.empty()) {
		//Battery saves are disabled (used by history viewer)
		return;
	}

	_hasBattery = true;
	ofstream out(GetBasePath(extension), ios::binary);
	if(out) {
		out.write((char*)data, length);
	}
}

vector<uint8_t> BatteryManager::LoadBattery(string extension)
{
	if(_romName.empty()) {
		//Battery saves are disabled (used by history viewer)
		return {};
	}

	shared_ptr<IBatteryProvider> provider = _provider.lock();
	
	vector<uint8_t> batteryData;
	if(provider) {
		//Used by movie player to provider initial state of ram at startup
		batteryData = provider->LoadBattery(extension);
	} else {
		VirtualFile file = GetBasePath(extension);
		if(file.IsValid()) {
			file.ReadFile(batteryData);
		}
	}

	if(!batteryData.empty()) {
		shared_ptr<IBatteryRecorder> recorder = _recorder.lock();
		if(recorder) {
			//Used by movies to record initial state of battery-backed ram at power on
			recorder->OnLoadBattery(extension, batteryData);
		}
	}

	_hasBattery = true;
	return batteryData;
}

void BatteryManager::LoadBattery(string extension, uint8_t* data, uint32_t length)
{
	vector<uint8_t> batteryData = LoadBattery(extension);
	memcpy(data, batteryData.data(), std::min((uint32_t)batteryData.size(), length));
}

uint32_t BatteryManager::GetBatteryFileSize(string extension)
{
	return (uint32_t)LoadBattery(extension).size();
}