#coding=utf-8

# 8888888b. 88888888888      888888b.                    888            8888888888                               
# 888   Y88b    888          888  "88b                   888            888                                      
# 888    888    888          888  .88P                   888            888                                      
# 888   d88P    888          8888888K.  888d888 888  888 888888 .d88b.  8888888  .d88b.  888d888 .d8888b .d88b.  
# 8888888P"     888          888  "Y88b 888P"   888  888 888   d8P  Y8b 888     d88""88b 888P"  d88P"   d8P  Y8b 
# 888           888   888888 888    888 888     888  888 888   88888888 888     888  888 888    888     88888888 
# 888           888          888   d88P 888     Y88b 888 Y88b. Y8b.     888     Y88..88P 888    Y88b.   Y8b.     
# 888           888          8888888P"  888      "Y88888  "Y888 "Y8888  888      "Y88P"  888     "Y8888P "Y8888  

from Core import Base as Base
from Utils import Logger as Log

from pythonping import ping
import time


def uptime():
    uptime = time.time() - Base.startTime
    uptime = time.strftime("%H:%M:%S", time.gmtime(uptime))
    return uptime

def algoTime(startTime):
    algoTime = time.time() - startTime
    ms = round(algoTime * 1000)

    algoTime = time.strftime("%H:%M:%S", time.gmtime(algoTime)) + ":" + str(ms)
    timeMsg = "algorithm uptime:  " + str(algoTime)
    return timeMsg