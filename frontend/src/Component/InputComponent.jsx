export default function InputComponent({labelText,changeHandle, inputType, inputValue,placeholderValue,validationError}){
    return (
        <>
            <div className="mb-3">
                <div className="d-flex justify-content-between ">
                    <label  className="form-label mb-0">{labelText}</label>
                    <p className="mb-0 small text-danger">{validationError && "*" + validationError[0] }</p>
                </div>
                  <input onChange={changeHandle}
                 type={inputType}
                 className="form-control bg-body-tertiary" 
                 value={inputValue} 
                 
                 placeholder={placeholderValue}/>
                 
                </div>
        </>
    )
}