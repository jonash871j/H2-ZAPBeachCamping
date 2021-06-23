#pragma once

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