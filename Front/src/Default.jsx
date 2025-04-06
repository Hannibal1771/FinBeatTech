import React, {useEffect, useState} from 'react';
import axios from "axios";
import DefaultTable from "./components/DefaultTable";
import DefaultForm from "./components/DefaultForm";
import DefaultModal from "./modal/DefaultModal";
import Pagination from "./components/Pagination";
import {useDefaultFetching} from "./hooks/useDefaultFetching";
import DefaultService from "./API/DefaultService";

const Default = () => {
    const [modal, setModal] = useState(false)

    const [tableValues, setTableValues] = useState([])
    const [filterValue, setFilterValue] = useState("");
    const [currentPage, setCurrentPage] = useState(1)
    const [rowsPerPage, setRowsPerPage] = useState(5)
    const [totalRows, setTotalRows] = useState(0)

    const enabledRowsPerPage = [5, 10, 25, 50, 100];


    const [getValues,,] = useDefaultFetching(async (page) => {
        const response = await DefaultService.getAll(rowsPerPage, page, filterValue)
        setTableValues(response.data.defaultList)
        setTotalRows(response.data.totalRows)
    })

    useEffect(() => {
        getValues(currentPage);
    }, [currentPage, rowsPerPage]);

    const paginate = pageNumber => setCurrentPage(pageNumber);

    const create = async (newValue) =>{
        const response = await DefaultService.sendValue(newValue.code, newValue.value)
        if(response.status === 200){
            alert("OK")
        }
        else{
            alert("ERROR")
        }

        setModal(false)
    }

    const getValuesByFilter = () => getValues(1);

    const rowsPerPageHandler = e => {
        setCurrentPage(1)
        setRowsPerPage(e.target.value)
    }

    const openCreate = () => {
        setRowsPerPage(1)
        setModal(true)
    }

    return (
        <div>
            <div style={{marginLeft: '85px', marginTop: "40px"}}>
                <input onChange={(e) => setFilterValue(e.target.value)} style={{marginRight: '25px'}} placeholder="Введите Value" value={filterValue}/>
                <button onClick={getValuesByFilter}>Загрузить данные</button>
                <button style={{marginLeft: '15px'}} onClick={openCreate}>Добавить</button>
            </div>
            <DefaultModal visible={modal} setVisible={setModal}>
                <DefaultForm create={create}/>
            </DefaultModal>
            <div style={{width: '80%', margin: '50px auto', marginRight: '600px'}}>
                <DefaultTable values = {tableValues}/>
            </div>
            <div style={{marginLeft: '85px', marginTop: "40px"}}>
                <Pagination
                    rowsPerPage={rowsPerPage}
                    totalRows={totalRows}
                    paginate={paginate}
                />
                <select style={{width: "50px"}} onChange={rowsPerPageHandler}>
                    {enabledRowsPerPage.map((elem, index) => (
                        <option key={index} value={elem}> {elem}</option>
                    ))}
                </select>
            </div>
        </div>
    );
};

export default Default;