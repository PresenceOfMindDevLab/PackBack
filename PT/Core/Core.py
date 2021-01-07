from LowLevel import LowLevel as LL
from Utils import parser as pars
from Utils import Logger as Log
import numpy as np
import time

def setMaxWeight():
    maxWeight = int(input("Input Bag Size: "))
    return maxWeight

def addMatrixVpS(itemMatrix):
    itemMatrixVpS = np.array([[],[],[],[]])
    m, nx = itemMatrix.shape
    n = 0
    for n in range(nx):
        item = itemMatrix[:,n]
        ID = item[0]
        value = item[1]
        size = item[2]
        VpS = item[1]/item[2]
        VpS = np.around(VpS, decimals=2)
        
        newColumn = np.array([ID,value,size,VpS])
        itemMatrixVpS = np.column_stack((itemMatrixVpS,newColumn))
        
        n + 1
    Log.i(itemMatrixVpS)
    return itemMatrixVpS

def sortMatrix(itemMatrix):
    sortedArr = itemMatrix [:,itemMatrix[3].argsort()[::-1]]
    Log.d(sortedArr)
    return sortedArr

def algo(sortedArr, maxWeight):
    startTime = time.time()

    m, nx = sortedArr.shape
    PB = np.array([[],[],[],[]])
    nameList = []
    weight = maxWeight
    for n in range(nx):
        item = sortedArr[:,n]
        ID = item[0]
        value = item[1]
        size = item[2]
        VpS = item[3]

        if size < weight:
            weight = weight - size

            Log.d("item " + str(ID.astype(int)) + " was added to the bag")
            newColumn = np.array([ID,value,size,VpS])
            PB = np.column_stack((PB,newColumn))
            name = pars.loadName(ID)
            nameList.append(name)
        else:
            Log.d("item " + str(ID.astype(int)) + " was not added to the bag")
        n = n + 1
    Log.i(PB)
    print(nameList)
    Log.i(LL.algoTime(startTime))
    Log.d("finished")
