import json
import numpy as np

from Utils import Logger as Log

def loadItems():

    itemMatrix = np.array([[],[]])
    with open("Core/Data/items.json") as items:
        data = json.load(items)
        Log.i(data)
        for item in data:
            value = int(data[item]["value"])
            Log.i(value)
            size = int(data[item]["size"])
            Log.i(size)
            newColumn = np.array([value, size])
            Log.i(newColumn)

            itemMatrix = np.column_stack((itemMatrix, newColumn))
    
    print(itemMatrix)
    return itemMatrix

