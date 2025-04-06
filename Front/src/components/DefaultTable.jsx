import React, {useEffect, useMemo, useState} from 'react';
import {DataTable} from "primereact/datatable";
import {Column} from "primereact/column";
import '../style.css'

const DefaultTable = ({values, loading}) => {

    if(loading){
        return <h2>Loading...</h2>
    }

    return  <>
        <DataTable
            value={values}
            className="data-table"
            >
            <Column field="id" header="id" headerClassName="id" style={{ width: '25%' }} />
            <Column field="code" header="code" headerClassName="code" style={{ width: '25%' }} />
            <Column field="value" header="value" headerClassName="value" style={{ width: '25%' }} />
        </DataTable>
    </>
};

export default DefaultTable;