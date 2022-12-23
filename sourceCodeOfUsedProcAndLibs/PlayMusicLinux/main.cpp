#include <iostream>
#include "irrKlang.h"
#include <string>
#include <list>
#include <sys/types.h>
#pragma comment(lib, "irrKlang.lib") // link with irrKlang.dll
using namespace irrklang;
using namespace std;



void LPlay(const char* song, bool loopSongFlag);
void LStop();
void LContinue();
void LVolume(int value);
void LRewind(int time);
void LRestart();
int LGetCurrentLeangth();
int LGetMaxLeanght();
void LStopAndClean();
bool LIsFinished();



ISoundEngine *engine = createIrrKlangDevice();
const char* path = "/home/theuser/Programms/Cs/TestMusic/DS1/29.-Dark-Souls-Remastered-Soundtrack-_OST_-Gwyn_-Lord-of-Cinder.wav";
ISound *sounder; 

float volume = 1;

int main()
{
    cout << "LPLayerStarted" << "\n";
    //sounder = engine -> play2D(path, true);
    LPlay(path, true);
    int n;
    cin >> n;
    return 0;
}


void LPlay(const char* song, bool loopSongFlag=false)
{
    
    engine -> setSoundVolume(volume);
    sounder = engine -> play2D(song, loopSongFlag);
}

void LStop()
{
    sounder -> setIsPaused(true); // unpause the sound
}

void LContinue()
{
    sounder -> setIsPaused(false);
}

void LVolume(int value)
{
    volume = value / 1000.0;
    engine -> setSoundVolume((float)volume);
}

// Перемотка
void LRewind(int time)
{
    if ((sounder -> getPlayPosition()) >= (uint)time * 1000)
    {
        sounder -> setPlayPosition((sounder -> getPlayPosition()) + (uint)time * 1000);
    }
    else
    {
        if(time < 0)
        {
            sounder -> setPlayPosition(0);
        }
        else
        {
            sounder -> setPlayPosition((sounder -> getPlayPosition())+ (uint)time * 1000);
        }
    }
}

void LRestart()
{
    sounder -> setPlayPosition(0);
}

int LGetCurrentLeangth()
{
    return (sounder -> getPlayPosition());
}

int LGetMaxLeanght()
{
    return (sounder -> getPlayLength()); 
}

bool LIsFinished()
{
    return (sounder -> isFinished());
}

void LStopAndClean() 
{
    engine -> drop();
}
