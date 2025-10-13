import { Link } from "react-router-dom"
export default function FormComponent({title,subTitle,optional,children,linkTo}){
    return(
        <>
        <div className="d-flex justify-content-center align-items-center vh-100"> 
            <div className="container-md ">
                <div className="row">
                    <div className="col-6 mx-auto">
                         <div className="card rounded-4" >
                          
                    <div className="card-body">
                        <h5 className="card-title text-center">{title}</h5>
                        <h6 className="card-subtitle mb-2 text-center text-body-tertiary mb-4" >{subTitle}</h6>
                        {children}
                    <div className="text-center my-4">
                      <Link to={linkTo}>{optional}</Link>
                    </div>
                    </div>
                   </div>    
                    </div>
                </div>
            
        </div>
        </div>
        </>
    )
}