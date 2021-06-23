#pragma once
#include "enums.h"

class LedHandler
{
public:
    //Y_Amount = amount of leds
    static const int Y_AMOUNT = 8;
    //X_Amount = amount of colors(RGB)
    static const int X_AMOUNT = 3;

public:
    //Used to intiialize ledpins
    void Initialize();
    //Used to change color of led
    void ChangeLed(int y, LedColor ledColor);
};