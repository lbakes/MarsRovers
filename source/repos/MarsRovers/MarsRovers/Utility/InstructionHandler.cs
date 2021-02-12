using MarsRovers.Models;
using MarsRovers.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Utility
{
    public class InstructionHandler
    {
        static string[] Cardinals = { "N", "E", "S", "W" };
        private int _xBoundry;
        private int _yBoundry;
        private int _curX;
        private int _curY;
        private int _curOrientation;

        public List<string> GetUpdatedPosition(RoverViewModel rvm)
        {
            List<string> results = new List<string>();

            _xBoundry = rvm.Grid.X;
            _yBoundry = rvm.Grid.Y;

            foreach (Rover rover in rvm.Rovers)
            {
                StringBuilder curPos = new StringBuilder(rover.InitialPosition);

                _curX = curPos[0] - '0';
                _curY = curPos[1] - '0';
                _curOrientation = Array.FindIndex(Cardinals, row => row.Contains(char.ToUpper(curPos[2])));

                string instructions = rover.Instructions;

                for (int i = 0; i < instructions.Length; i++)
                {
                    switch (char.ToUpper(instructions[i]))
                    {
                        case 'R':
                            OrientRight();
                            break;
                        case 'L':
                            OrientLeft();
                            break;
                        case 'M':
                            Move();
                            break;
                        default:
                            Console.WriteLine("Invalid Character in Rover Instruction string");
                            break;
                    }
                }

                string result = _curX.ToString() + _curY.ToString() + Cardinals[_curOrientation];
                results.Add(result);
            }

            return results;
        }

        private void OrientRight()
        {
            if (_curOrientation == 3)
            {
                _curOrientation = 0;
            }
            else
            {
                _curOrientation = _curOrientation + 1;
            }
        }

        private void OrientLeft()
        {
            if (_curOrientation == 0)
            {
                _curOrientation = 3;
            }
            else
            {
                _curOrientation = _curOrientation - 1;
            }
        }


        private void Move()
        {
            switch (_curOrientation)
            {
                case 0:
                    if (_curY != _yBoundry)
                    {
                        _curY = _curY + 1;
                    }
                    break;
                case 1:
                    if (_curX != _xBoundry)
                    {
                        _curX = _curX + 1;
                    }
                    break;
                case 2:
                    if (_curY != 0)
                    {
                        _curY = _curY - 1;
                    }
                    break;
                case 3:
                    if (_curX != 0)
                    {
                        _curX = _curX - 1;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Character in Rover Instruction string");
                    break;
            }
        }
    }
}

