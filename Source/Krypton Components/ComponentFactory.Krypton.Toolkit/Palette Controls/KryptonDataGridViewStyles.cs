﻿// *****************************************************************************
// BSD 3-Clause License (https://github.com/ComponentFactory/Krypton/blob/master/LICENSE)
//  © Component Factory Pty Ltd, 2006-2020, All rights reserved.
// The software and associated documentation supplied hereunder are the 
//  proprietary information of Component Factory Pty Ltd, 13 Swallows Close, 
//  Mornington, Vic 3931, Australia and are supplied subject to license terms.
// 
//  Modifications by Peter Wagner(aka Wagnerp) & Simon Coghlan(aka Smurf-IV) 2017 - 2020. All rights reserved. (https://github.com/Wagnerp/Krypton-NET-5.490)
//  Version 5.490.0.0  www.ComponentFactory.com
// *****************************************************************************

using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit
{
    /// <summary>
    /// Storage for data grid view display styles.
    /// </summary>
    public class DataGridViewStyles : Storage
    {
        #region Instance Fields
        private readonly KryptonDataGridView _dataGridView;
        private DataGridViewStyle _gridStyle;
        private GridStyle _columnStyle;
        private GridStyle _rowStyle;
        private GridStyle _dataCellStyle;
        private PaletteBackStyle _backgroundStyle;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the DataGridViewStyles class.
        /// </summary>
        /// <param name="dataGridView">Reference to owning control.</param>
        public DataGridViewStyles(KryptonDataGridView dataGridView)
        {
            Debug.Assert(dataGridView != null);
            _dataGridView = dataGridView;
            _gridStyle = DataGridViewStyle.List;
            _columnStyle = GridStyle.List;
            _rowStyle = GridStyle.List;
            _dataCellStyle = GridStyle.List;
            _backgroundStyle = PaletteBackStyle.GridBackgroundList;
        }
        #endregion

        #region IsDefault
        /// <summary>
        /// Gets a value indicating if all values are default.
        /// </summary>
        public override bool IsDefault => (_gridStyle == DataGridViewStyle.List);

        #endregion

        #region Style
        /// <summary>
        /// Gets and sets the overall grid style.
        /// </summary>
        [Category("Visuals")]
        [Description("Overall grid style.")]
        [RefreshProperties(RefreshProperties.All)]
        public DataGridViewStyle Style
        {
            get => _gridStyle;

            set
            {
                if (_gridStyle != value)
                {
                    _gridStyle = value;

                    switch (_gridStyle)
                    {
                        case DataGridViewStyle.List:
                            _columnStyle = GridStyle.List;
                            _rowStyle = GridStyle.List;
                            _dataCellStyle = GridStyle.List;
                            _backgroundStyle = PaletteBackStyle.GridBackgroundList;
                            break;
                        case DataGridViewStyle.Sheet:
                            _columnStyle = GridStyle.Sheet;
                            _rowStyle = GridStyle.Sheet;
                            _dataCellStyle = GridStyle.Sheet;
                            _backgroundStyle = PaletteBackStyle.GridBackgroundSheet;
                            break;
                        case DataGridViewStyle.Custom1:
                            _columnStyle = GridStyle.Custom1;
                            _rowStyle = GridStyle.Custom1;
                            _dataCellStyle = GridStyle.Custom1;
                            _backgroundStyle = PaletteBackStyle.GridBackgroundCustom1;
                            break;
                        case DataGridViewStyle.Custom2:
                            _columnStyle = GridStyle.Custom2;
                            _rowStyle = GridStyle.Custom2;
                            _dataCellStyle = GridStyle.Custom2;
                            _backgroundStyle = PaletteBackStyle.GridBackgroundCustom2;
                            break;
                        case DataGridViewStyle.Custom3:
                            _columnStyle = GridStyle.Custom3;
                            _rowStyle = GridStyle.Custom3;
                            _dataCellStyle = GridStyle.Custom3;
                            _backgroundStyle = PaletteBackStyle.GridBackgroundCustom3;
                            break;
                    }

                    _dataGridView.SyncStyles();
                    _dataGridView.PerformNeedPaint(false);
                }
            }
        }

        private bool ShouldSerializeStyle()
        {
            return (Style != DataGridViewStyle.List);
        }

        private void ResetStyle()
        {
            Style = DataGridViewStyle.List;
        }
        #endregion

        #region StyleColumn
        /// <summary>
        /// Gets and sets the header column grid style.
        /// </summary>
        [Category("Visuals")]
        [Description("Style of the header columns.")]
        [RefreshProperties(RefreshProperties.All)]
        public GridStyle StyleColumn
        {
            get => _columnStyle;

            set
            {
                if (_columnStyle != value)
                {
                    _columnStyle = value;
                    _gridStyle = DataGridViewStyle.Mixed;

                    switch (_columnStyle)
                    {
                        case GridStyle.List:
                            if ((_rowStyle == GridStyle.List) &&
                                (_dataCellStyle == GridStyle.List) &&
                                (_backgroundStyle == PaletteBackStyle.GridBackgroundList))
                            {
                                _gridStyle = DataGridViewStyle.List;
                            }

                            break;
                        case GridStyle.Sheet:
                            if ((_rowStyle == GridStyle.Sheet) &&
                                (_dataCellStyle == GridStyle.Sheet) &&
                                (_backgroundStyle == PaletteBackStyle.GridBackgroundSheet))
                            {
                                _gridStyle = DataGridViewStyle.Sheet;
                            }

                            break;

                        case GridStyle.Custom1:
                            if ((_rowStyle == GridStyle.Custom1) &&
                                (_dataCellStyle == GridStyle.Custom1) &&
                                (_backgroundStyle == PaletteBackStyle.GridBackgroundCustom1))
                            {
                                _gridStyle = DataGridViewStyle.Custom1;
                            }
                            break;

                        case GridStyle.Custom2:
                            if ((_rowStyle == GridStyle.Custom2) &&
                                (_dataCellStyle == GridStyle.Custom2) &&
                                (_backgroundStyle == PaletteBackStyle.GridBackgroundCustom2))
                            {
                                _gridStyle = DataGridViewStyle.Custom2;
                            }
                            break;

                        case GridStyle.Custom3:
                            if ((_rowStyle == GridStyle.Custom3) &&
                                (_dataCellStyle == GridStyle.Custom3) &&
                                (_backgroundStyle == PaletteBackStyle.GridBackgroundCustom3))
                            {
                                _gridStyle = DataGridViewStyle.Custom3;
                            }
                            break;
                    }

                    _dataGridView.SyncStyles();
                    _dataGridView.PerformNeedPaint(false);
                }
            }
        }

        private bool ShouldSerializeStyleColumn()
        {
            return (StyleColumn != GridStyle.List);
        }

        private void ResetStyleColumn()
        {
            StyleColumn = GridStyle.List;
        }
        #endregion

        #region StyleRow
        /// <summary>
        /// Gets and sets the header row grid style.
        /// </summary>
        [Category("Visuals")]
        [Description("Style of the header rows.")]
        [RefreshProperties(RefreshProperties.All)]
        public GridStyle StyleRow
        {
            get => _rowStyle;

            set
            {
                if (_rowStyle != value)
                {
                    _rowStyle = value;
                    _gridStyle = DataGridViewStyle.Mixed;

                    switch (_columnStyle)
                    {
                        case GridStyle.List:
                            if ((_columnStyle == GridStyle.List) &&
                                (_dataCellStyle == GridStyle.List) &&
                                (_backgroundStyle == PaletteBackStyle.GridBackgroundList))
                            {
                                _gridStyle = DataGridViewStyle.List;
                            }

                            break;
                        case GridStyle.Sheet:
                            if ((_columnStyle == GridStyle.Sheet) &&
                                (_dataCellStyle == GridStyle.Sheet) &&
                                (_backgroundStyle == PaletteBackStyle.GridBackgroundSheet))
                            {
                                _gridStyle = DataGridViewStyle.Sheet;
                            }

                            break;

                        case GridStyle.Custom1:
                            if ((_columnStyle == GridStyle.Custom1) &&
                                (_dataCellStyle == GridStyle.Custom1) &&
                                (_backgroundStyle == PaletteBackStyle.GridBackgroundCustom1))
                            {
                                _gridStyle = DataGridViewStyle.Custom1;
                            }
                            break;

                        case GridStyle.Custom2:
                            if ((_columnStyle == GridStyle.Custom2) &&
                                (_dataCellStyle == GridStyle.Custom2) &&
                                (_backgroundStyle == PaletteBackStyle.GridBackgroundCustom2))
                            {
                                _gridStyle = DataGridViewStyle.Custom2;
                            }
                            break;

                        case GridStyle.Custom3:
                            if ((_columnStyle == GridStyle.Custom3) &&
                                (_dataCellStyle == GridStyle.Custom3) &&
                                (_backgroundStyle == PaletteBackStyle.GridBackgroundCustom3))
                            {
                                _gridStyle = DataGridViewStyle.Custom3;
                            }
                            break;
                    }

                    _dataGridView.SyncStyles();
                    _dataGridView.PerformNeedPaint(false);
                }
            }
        }

        private bool ShouldSerializeStyleRow()
        {
            return (StyleRow != GridStyle.List);
        }

        private void ResetStyleRow()
        {
            StyleRow = GridStyle.List;
        }
        #endregion

        #region StyleDataCells
        /// <summary>
        /// Gets and sets the data cell grid style.
        /// </summary>
        [Category("Visuals")]
        [Description("Style of the data cells.")]
        [RefreshProperties(RefreshProperties.All)]
        public GridStyle StyleDataCells
        {
            get => _dataCellStyle;

            set
            {
                if (_dataCellStyle != value)
                {
                    _dataCellStyle = value;
                    _gridStyle = DataGridViewStyle.Mixed;

                    switch (_columnStyle)
                    {
                        case GridStyle.List:
                            if ((_columnStyle == GridStyle.List) &&
                                (_rowStyle == GridStyle.List) &&
                                (_backgroundStyle == PaletteBackStyle.GridBackgroundList))
                            {
                                _gridStyle = DataGridViewStyle.List;
                            }

                            break;
                        case GridStyle.Sheet:
                            if ((_columnStyle == GridStyle.Sheet) &&
                                (_rowStyle == GridStyle.Sheet) &&
                                (_backgroundStyle == PaletteBackStyle.GridBackgroundSheet))
                            {
                                _gridStyle = DataGridViewStyle.Sheet;
                            }

                            break;

                        case GridStyle.Custom1:
                            if ((_columnStyle == GridStyle.Custom1) &&
                                (_rowStyle == GridStyle.Custom1) &&
                                (_backgroundStyle == PaletteBackStyle.GridBackgroundCustom1))
                            {
                                _gridStyle = DataGridViewStyle.Custom1;
                            }
                            break;

                        case GridStyle.Custom2:
                            if ((_columnStyle == GridStyle.Custom2) &&
                                (_rowStyle == GridStyle.Custom2) &&
                                (_backgroundStyle == PaletteBackStyle.GridBackgroundCustom2))
                            {
                                _gridStyle = DataGridViewStyle.Custom2;
                            }
                            break;

                        case GridStyle.Custom3:
                            if ((_columnStyle == GridStyle.Custom3) &&
                                (_rowStyle == GridStyle.Custom3) &&
                                (_backgroundStyle == PaletteBackStyle.GridBackgroundCustom3))
                            {
                                _gridStyle = DataGridViewStyle.Custom3;
                            }
                            break;
                    }

                    _dataGridView.SyncStyles();
                    _dataGridView.PerformNeedPaint(false);
                }
            }
        }

        private bool ShouldSerializeStyleDataCells()
        {
            return (StyleDataCells != GridStyle.List);
        }

        private void ResetStyleDataCells()
        {
            StyleDataCells = GridStyle.List;
        }
        #endregion

        #region StyleBackground
        /// <summary>
        /// Gets and sets the data cell grid style.
        /// </summary>
        [Category("Visuals")]
        [Description("Style of the data cells.")]
        [RefreshProperties(RefreshProperties.All)]
        public PaletteBackStyle StyleBackground
        {
            get => _backgroundStyle;

            set
            {
                if (_backgroundStyle != value)
                {
                    _backgroundStyle = value;
                    _gridStyle = DataGridViewStyle.Mixed;

                    switch (_backgroundStyle)
                    {
                        case PaletteBackStyle.GridBackgroundList when (_columnStyle == GridStyle.List) && (_rowStyle == GridStyle.List) && (_dataCellStyle == GridStyle.List):
                            _gridStyle = DataGridViewStyle.List;
                            break;
                        case PaletteBackStyle.GridBackgroundSheet when (_columnStyle == GridStyle.Sheet) && (_rowStyle == GridStyle.Sheet) && (_dataCellStyle == GridStyle.Sheet):
                            _gridStyle = DataGridViewStyle.Sheet;
                            break;
                        case PaletteBackStyle.GridBackgroundCustom1 when (_columnStyle == GridStyle.Custom1) && (_rowStyle == GridStyle.Custom1) && (_dataCellStyle == GridStyle.Custom1):
                            _gridStyle = DataGridViewStyle.Custom1;
                            break;
                        case PaletteBackStyle.GridBackgroundCustom2 when (_columnStyle == GridStyle.Custom2) && (_rowStyle == GridStyle.Custom2) && (_dataCellStyle == GridStyle.Custom2):
                            _gridStyle = DataGridViewStyle.Custom2;
                            break;
                        case PaletteBackStyle.GridBackgroundCustom3 when (_columnStyle == GridStyle.Custom3) && (_rowStyle == GridStyle.Custom3) && (_dataCellStyle == GridStyle.Custom3):
                            _gridStyle = DataGridViewStyle.Custom3;
                            break;
                    }

                    _dataGridView.SyncStyles();
                    _dataGridView.PerformNeedPaint(false);
                }
            }
        }

        private bool ShouldSerializeStyleBackground()
        {
            return (StyleBackground != PaletteBackStyle.GridBackgroundList);
        }

        private void ResetStyleBackground()
        {
            StyleBackground = PaletteBackStyle.GridBackgroundList;
        }
        #endregion
    }
}
