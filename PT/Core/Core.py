import numpy as np
from Utils import Logger as Log

def setMaxWeight():
    maxWeight = input("Input Bag Size: ")
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
        itemMatrixVpS = np.column_stack((itemMatrixVpS,newColumn)) # change to row_stack
        
        n + 1
    Log.i(itemMatrixVpS)
    return itemMatrixVpS

def sortMatrix(itemMatrix):
    itemMatrix.view('i8,i8,i8,i8,i8,i8,i8,i8,i8').sort(order=['f2'], axis=1) #
    Log.d(itemMatrix)