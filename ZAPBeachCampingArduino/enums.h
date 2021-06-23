#pragma once
typedef signed char int8_t;
typedef unsigned char uint8_t;
typedef signed int int16_t;
typedef unsigned int uint16_t;
typedef signed long int int32_t;
typedef unsigned long int uint32_t;

enum class SpotStatus
{
    NoReservation = 1,
    AnyReservation = 2,
    CommingToday = 3,
    LeavingToday = 4
};
enum class LedColor
{
  None = -1,
  Red = 0,
  Green = 1,
  Blue = 2,
};