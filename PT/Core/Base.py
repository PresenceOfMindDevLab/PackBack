#coding=utf-8

# 8888888b. 88888888888      888888b.                    888            8888888888                               
# 888   Y88b    888          888  "88b                   888            888                                      
# 888    888    888          888  .88P                   888            888                                      
# 888   d88P    888          8888888K.  888d888 888  888 888888 .d88b.  8888888  .d88b.  888d888 .d8888b .d88b.  
# 8888888P"     888          888  "Y88b 888P"   888  888 888   d8P  Y8b 888     d88""88b 888P"  d88P"   d8P  Y8b 
# 888           888   888888 888    888 888     888  888 888   88888888 888     888  888 888    888     88888888 
# 888           888          888   d88P 888     Y88b 888 Y88b. Y8b.     888     Y88..88P 888    Y88b.   Y8b.     
# 888           888          8888888P"  888      "Y88888  "Y888 "Y8888  888      "Y88P"  888     "Y8888P "Y8888  

from Utils import Logger as Log
from Core import Core
from Utils import parser

import operator
import re 
import time
import random
import sys
import psutil
import json

startTime = time.time()
Log.d("Set start time: " + str(time.strftime("%H:%M:%S", time.gmtime(startTime))))

def PTRun():
    maxWeight = Core.setMaxWeight()

    items = parser.loadItems()
    VpSM = Core.addMatrixVpS(items)
    Core.sortMatrix(VpSM)


def idle():
    while True:
        Log.d("Run Idle")
        time.sleep(10)
