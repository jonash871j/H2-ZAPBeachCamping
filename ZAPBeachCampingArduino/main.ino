const int LEDY_AMOUNT = 8;
const int LEDX_AMOUNT = 3;

int ledPins[LEDY_AMOUNT][LEDX_AMOUNT]
{
  53,51,49,
  52,50,48,
  47,45,43,
  46,44,42,
  41,39,37,
  40,38,36,
  35,33,31,
  34,32,30
};

enum class SpotStatus
{
  NoOrder = 1,
  LeavingYoday = 2,
  OrderReservated = 3,
  CommingToday = 4
};
enum class LedColor
{
  None = -1,
  Red = 0,
  Green = 1,
  Blue = 2,
  Orange,
  Cyan,
  Purple
};

bool ReadUSBBuffer(uint8_t* buffer, uint32_t size)
{
  if (Serial.available())
  {
      Serial.readBytes(buffer, size);
      return true;
  }
  return false;
}

void ChangeLed(int y, LedColor ledColor)
{
    for (int i = 0; i < 3; i++)
    {
      digitalWrite(ledPins[y][i], LOW);
    }

  if (ledColor != LedColor::None)
  {
    if (ledColor == LedColor::Orange)
    {
      digitalWrite(ledPins[y][(int)LedColor::Red], HIGH);
      digitalWrite(ledPins[y][(int)LedColor::Green], HIGH);
    }
    else if (ledColor == LedColor::Cyan)
    {
      digitalWrite(ledPins[y][(int)LedColor::Blue], HIGH);
      digitalWrite(ledPins[y][(int)LedColor::Green], HIGH);
    }
    else if (ledColor == LedColor::Purple)
    {
      digitalWrite(ledPins[y][(int)LedColor::Blue], HIGH);
      digitalWrite(ledPins[y][(int)LedColor::Red], HIGH);
    }
    else
    {
      digitalWrite(ledPins[y][(int)ledColor], HIGH); 
    }
  }
}

SpotStatus* GetSpotStatues(int& length)
{
  length = 8;
  SpotStatus* spotStatuses = new SpotStatus[length];
  uint8_t buffer[30];
  buffer[0] = 0;
  while (buffer[0] == 0)
  {
    ReadUSBBuffer(buffer, 30);
  }
  for (int i = 0; i < length; i++)
  {
    spotStatuses[i] = (SpotStatus)buffer[i];
  }
  return spotStatuses;
}

void setup() {
Serial.begin(11200);
for (int i = 0; i < LEDY_AMOUNT; i++)
{
  for (int j = 0; j < LEDX_AMOUNT; j++)
  {
      pinMode(ledPins[i][j], OUTPUT);
  }
}

}

void loop() 
{
  int length;
  SpotStatus* spotStatues = GetSpotStatues(length);

  for (int i = 0; i < length; i++)
  {
    if (spotStatues[i] == SpotStatus::NoOrder)
    {
      ChangeLed(i, LedColor::Green);
    }
    else if (spotStatues[i] == SpotStatus::CommingToday)
    {
      ChangeLed(i, LedColor::None);
    }
    else if (spotStatues[i] == SpotStatus::LeavingYoday)
    {
      ChangeLed(i, LedColor::Blue);
    }
    else if (spotStatues[i] == SpotStatus::OrderReservated)
    {
      ChangeLed(i, LedColor::Red);
    }
  }
  delete spotStatues;
}




