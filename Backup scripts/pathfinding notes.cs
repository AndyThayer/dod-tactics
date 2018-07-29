public static string[,] FindAvailableCells(float movPoints, int posX, int posY){
        
        // add 1 to these array indices so we can 1 : 1 the coords (and just ignore the zero indices)
        string[,] available = new string[GlobalVariables.boardWidth+1,GlobalVariables.boardHeight+1];
        bool[,] considered = new bool[GlobalVariables.boardWidth+1,GlobalVariables.boardHeight+1];
        Vector3Int source = new Vector3Int(posX,posY,0);
        float movementPoints = movPoints;
        int thisMV;
        float MVcost;
        available[source.x,source.y] = movementPoints.ToString();

        bool processing = true;
        int inc = 0;
        while(processing || inc >= 1000){
            for(int c = 1; c < available.GetLength(0); c++){
                for(int r = 1; r < available.GetLength(1); r++){
                    if(available[ c,r ] != null){
                        processing = true;
                        if( considered[ c,r ] ){
                            processing = false;
                        }else{
                            processing = true;

                             // Up
                            if( (r+1) <= GlobalVariables.boardHeight){
                                MVcost = GlobalVariables.tilesMatrix[ c,(r+1) ].movementCost;
                                thisMV = Int32.Parse(available[ c,r ]);
                                if( MVcost <= thisMV ){ // if we have enough MV to make it to this cell
                                    if( available[ c,(r+1) ] == null ){
                                        available[ c,(r+1) ] = (thisMV - MVcost).ToString();
                                        Debug.Log(source.ToString() + ":Up 1st at " + c + " " + (r+1) + " we have " + available[ c,(r+1) ]);
                                    }else if( ((thisMV - MVcost) > Int32.Parse(available[ c,(r+1) ])) ){
                                        available[ c,(r+1) ] = (thisMV - MVcost).ToString();
                                        Debug.Log(source.ToString() + ":Up 2nd at " + c + " " + (r+1) + " we have " + available[ c,(r+1) ]);
                                    }
                                }
                            }

                            // Down
                            if( (r-1) > 0){
                                MVcost = GlobalVariables.tilesMatrix[ c,(r-1) ].movementCost;
                                thisMV = Int32.Parse(available[ c,r ]);
                                // backMV = ;
                                if( MVcost <= thisMV ){
                                    if( available[ c,(r-1) ] == null ){
                                        available[ c,(r-1) ] = (thisMV - MVcost).ToString();
                                        Debug.Log(source.ToString() + ":Down 1st at " + c + " " + (r-1) + " we have " + available[ c,(r-1) ]);
                                    }else if( ((thisMV - MVcost) > Int32.Parse(available[ c,(r-1) ])) ){
                                        available[ c,(r-1) ] = (thisMV - MVcost).ToString();
                                        Debug.Log(source.ToString() + ":Down 2nd at " + c + " " + (r-1) + " we have " + available[ c,(r-1) ]);
                                    }
                                }
                            }

                            // Left
                            if( (c-1) > 0){
                                MVcost = GlobalVariables.tilesMatrix[ (c-1),r ].movementCost;
                                thisMV = Int32.Parse(available[ c,r ]);
                                if( MVcost <= thisMV ){
                                    if( available[ (c-1),r ] == null ){
                                        available[ (c-1),r ] = (thisMV - MVcost).ToString();
                                        Debug.Log(source.ToString() + ":Left 1st at " + (c-1) + " " + r + " we have " + available[ (c-1),r ]);
                                    }else if( ((thisMV - MVcost) > Int32.Parse(available[ (c-1),r ])) ){
                                        available[ (c-1),r ] = (thisMV - MVcost).ToString();
                                        Debug.Log(source.ToString() + ":Left 2nd at " + (c-1) + " " + r + " we have " + available[ (c-1),r ]);
                                    }
                                }
                            }

                            // Right
                            if( (c+1) <= GlobalVariables.boardWidth){
                                MVcost = GlobalVariables.tilesMatrix[ (c+1),r ].movementCost;
                                thisMV = Int32.Parse(available[ c,r ]);
                                if( MVcost <= thisMV ){
                                    if( available[ (c+1),r ] == null ){
                                        available[ (c+1),r ] = (thisMV - MVcost).ToString();
                                        Debug.Log(source.ToString() + ":Right 1st at " + (c+1) + " " + r + " we have " + available[ (c+1),r ]);
                                    }else if( ((thisMV - MVcost) > Int32.Parse(available[ (c+1),r ])) ){
                                        available[ (c+1),r ] = (thisMV - MVcost).ToString();
                                        Debug.Log(source.ToString() + ":Right 2nd at " + (c+1) + " " + r + " we have " + available[ (c+1),r ]);
                                    }
                                }
                            }

                            considered[ c,r ]=true;
                            Debug.Log("<------Considered: " + c + " & " + r);
                        }
                    }
                    
                }
            }
            inc++; // just a safety net to ensure that we don't infinitely loop
            if(inc >= 1000){
                Debug.Log("Whoa! We hit the infinite loop safety net in FindAvailableCells()");
            }
        }

        // for(int c = 1; c < considered.GetLength(0); c++){
        //     for(int r = 1; r < considered.GetLength(1); r++){
        //         if(considered[ c,r ]){
        //             Debug.Log("Considered: " + c + " & " + r);
        //         }
        //     }
        // }

        return available;
    
    } // end FindAvailableCells()