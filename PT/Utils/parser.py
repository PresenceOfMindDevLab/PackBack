import json
import numpy as np

from Utils import Logger as Log

def loadItems():

    itemMatrix = np.array([[],[],[]])
    with open("Core/Data/items.json") as items:
        data = json.load(items)
        Log.i(data)
        for item in data:
            ID = int(data[item]["id"])
            value = int(data[item]["value"])
            Log.i(value)
            size = int(data[item]["size"])
            Log.i(size)
            newColumn = np.array([ID,value, size])
            Log.i(newColumn)

            itemMatrix = np.column_stack((itemMatrix, newColumn))
    
    print(itemMatrix)
    return itemMatrix

def loadName(ID):
    name = None
    ID = str(ID.astype(int))
    with open("Core/Data/items.json") as items:
        data = json.load(items)
        name = str(data[ID]["name"])
    return name


