#include "enums.h"
#include "led_handler.h"
#include "serial_buffer_reader.h"

LedHandler ledHandler;
SerialBufferReader serialBufferReader;

void setup()
{
    Serial.begin(11200);
    ledHandler.Initialize();
}

void loop()
{
    int length;
    SpotStatus* spotStatues = serialBufferReader.ReadSpotStatues(length);
    //Loop through spot Statues turn on and off led
    for (int i = 0; i < length; i++)
    {
        //Indicates no reservations. ledcolor of none
        if (spotStatues[i] == SpotStatus::NoReservation)
        {
            ledHandler.ChangeLed(i, LedColor::None);
        }
        //Indicates comming today. ledcolor of red
        else if (spotStatues[i] == SpotStatus::CommingToday)
        {
            ledHandler.ChangeLed(i, LedColor::Red);
        }
        //Indicates leaving today. ledcolor of blue
        else if (spotStatues[i] == SpotStatus::LeavingToday)
        {
            ledHandler.ChangeLed(i, LedColor::Blue);
        }
        //Indicates any reservation. ledcolor of green
        else if (spotStatues[i] == SpotStatus::AnyReservation)
        {
            ledHandler.ChangeLed(i, LedColor::Green);
        }
    }
    delete spotStatues;
}