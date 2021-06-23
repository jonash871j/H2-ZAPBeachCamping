#include "led_handler.h"
#include <Arduino.h>

static int ledPins[LedHandler::Y_AMOUNT][LedHandler::X_AMOUNT]
{
    //Map of led pins
    53,51,49,
    52,50,48,
    47,45,43,
    46,44,42,
    41,39,37,
    40,38,36,
    35,33,31,
    34,32,30
};

void LedHandler::Initialize()
{
    for (int i = 0; i < Y_AMOUNT; i++)
    {
        for (int j = 0; j < X_AMOUNT; j++)
        {
            pinMode(ledPins[i][j], OUTPUT);
        }
    }
}

void LedHandler::ChangeLed(int y, LedColor ledColor)
{    
    //Turn of RGB led
    for (int i = 0; i < 3; i++)
    {
        digitalWrite(ledPins[y][i], LOW);
    }
    //Sets ledcolor to none
    if (ledColor != LedColor::None)
    {
        //Sets ledcolor to red, green or blue
        digitalWrite(ledPins[y][(int)ledColor], HIGH); 
    }
}