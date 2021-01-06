# coding=utf-8

# 8888888b. 88888888888      888888b.                    888            8888888888                               
# 888   Y88b    888          888  "88b                   888            888                                      
# 888    888    888          888  .88P                   888            888                                      
# 888   d88P    888          8888888K.  888d888 888  888 888888 .d88b.  8888888  .d88b.  888d888 .d8888b .d88b.  
# 8888888P"     888          888  "Y88b 888P"   888  888 888   d8P  Y8b 888     d88""88b 888P"  d88P"   d8P  Y8b 
# 888           888   888888 888    888 888     888  888 888   88888888 888     888  888 888    888     88888888 
# 888           888          888   d88P 888     Y88b 888 Y88b. Y8b.     888     Y88..88P 888    Y88b.   Y8b.     
# 888           888          8888888P"  888      "Y88888  "Y888 "Y8888  888      "Y88P"  888     "Y8888P "Y8888  


import inspect
import time

def crt():
    return time.strftime("%H:%M:%S")

def call_elaborator(caller_foo):
    return caller_foo + (14 - len(caller_foo)) * " "

def printl(type, lmsg, foo):
    text = "[ %s ] %s - [from: %s ] - %s" % (type, crt(), foo, lmsg)
    with open("Files/log.txt", "a") as fl:
        fl.write(text + "\n")
    print(text)
    return True

def printe(text):
    with open("Files/error.txt", "a") as fl:
        fl.write(text + "\n")
        fl.close()
    print(text)

def d(text):
    printl("Debug ", text, call_elaborator(inspect.stack()[1][3]))


def i(text):
    printl("Info  ", text, call_elaborator(inspect.stack()[1][3]))


def a(text):
    printl("Action", text, call_elaborator(inspect.stack()[1][3]))


def w(text):
    printl("Warn  ", text, call_elaborator(inspect.stack()[1][3]))

def e(text):
    text = str(text)
    printe("[ Error  ] %s - [from: %s] - Error: %s line: ~%s" % (crt(), call_elaborator(inspect.stack()[1][3]), text,
                                                                inspect.getframeinfo(inspect.stack()[1][0]).lineno))
    return False

def critical(text, shutdown=True):
    text = str(text)
    printe("[CRITICAL] %s - [from: %s] - Error critical: %s line: ~%s" % (crt(), call_elaborator(inspect.stack()[1][3]), text,
                                                                        inspect.getframeinfo(
                                                                            inspect.stack()[1][0]).lineno))
    if shutdown:
        exit()