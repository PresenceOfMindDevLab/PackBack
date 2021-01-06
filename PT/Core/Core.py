import numpy as np
from Utils import Logger as Log

def setMaxWeight():
    maxWeight = int(input("Input Bag Size: "))
    return maxWeight

def addMatrixVpS(itemMatrix):
    itemMatrixVpS = np.array([[],[],[]])
    m, nx = itemMatrix.shape
    n = 0
    for n in range(nx):
        item = itemMatrix[:,n]
        value = item[0]
        size = item[1]
        VpS = item[0]/item[1]
        VpS = np.around(VpS, decimals=2)
        
        newColumn = np.array([value,size,VpS])
        itemMatrixVpS = np.column_stack((itemMatrixVpS,newColumn))
        
        n + 1
    Log.i(itemMatrixVpS)
    return itemMatrixVpS

def sortMatrix(itemMatrix):
    sortedArr = itemMatrix [:,itemMatrix[2].argsort()]
    return sortedArr

def algo(sortedArr, maxWeight):
    m, nx = sortedArr.shape
    PB = np.array([[],[],[]])
    weight = maxWeight
    for n in range(nx):
        item = sortedArr[:,n]
        value = item[0]
        size = item[1]
        VpS = item[2]

        if size < weight:
            weight = weight - size

            Log.d("item " + str(n) + " was added to the bag")
            newColumn = np.array([value,size,VpS])
            PB = np.column_stack((PB,newColumn))
        else:
            Log.d("item " + str(n) + " was not added to the bag")
        n = n + 1
    Log.i(PB)
    Log.d("finished")
