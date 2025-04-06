import React, {useState} from 'react';

const DefaultForm = ({create}) => {
    const [value, setValue] = useState({code: 0, value: ''})

    const addNewRow = (e) =>{
        e.preventDefault()
        create(value);
        setValue({code: 0, value: ''})
    }

    return (
        <form>
            <input
                type='text'
                placeholder='Код'
                value={value.code}
                onChange={e => setValue({...value, code: e.target.value})}
            />
            <input
                type='text'
                placeholder='Значение'
                value={value.value}
                onChange={e => setValue({...value, value: e.target.value})}
            />
            <button onClick={addNewRow}>Создать запись</button>
        </form>
    );
};

export default DefaultForm;