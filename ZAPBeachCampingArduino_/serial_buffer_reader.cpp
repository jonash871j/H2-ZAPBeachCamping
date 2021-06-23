#include "serial_buffer_reader.h"
#include "Arduino.h"

bool SerialBufferReader::ReadUSBBuffer(uint8_t* buffer, uint32_t size)
{
    //Check if serial is available
    if (Serial.available())
    {
        Serial.readBytes(buffer, size);
        return true;
    }
    return false;
}

SpotStatus* SerialBufferReader::ReadSpotStatues(int& length)
{
    length = 8;
    //instantiate spotStatus
    SpotStatus* spotStatuses = new SpotStatus[length];
    uint8_t buffer[30];
 
    // Sets first element in buffer to indicate that nothing has been written
    buffer[0] = 0;
    
    // Try read until the first element in buffer is zero
    while (buffer[0] == 0)
    {
        ReadUSBBuffer(buffer, 30);
    }
    // Converts buffer data into spot statues
    for (int i = 0; i < length; i++)
    {
        spotStatuses[i] = (SpotStatus)buffer[i];
    }

    return spotStatuses;
}
