#pragma once
#include "enums.h"

class SerialBufferReader
{
private:
    //Reads USB Buffer
    bool ReadUSBBuffer(uint8_t* buffer, uint32_t size);

public:
    //Reads status of spot
    SpotStatus* ReadSpotStatues(int& length);
};