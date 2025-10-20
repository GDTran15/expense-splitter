
import { Col,Button } from "react-bootstrap";

export default function ExpenseComponent({exp}){
    const user = JSON.parse(localStorage.getItem("user"));
   

    return(
        <>
        <Col key={exp.expenseId} xs={12} className="">
                                <div
                                    className="d-flex justify-content-between align-items-center border rounded-3 px-3 py-3 shadow mb-2"
                                    style={{ background: "#fff", fontSize: "0.9rem" }}
                                    >                                    
                                    <div>
                                      
                                        <div className="d-flex flex-column ">
                                        <h5 className="fw-semibold">{exp.expenseName}</h5>
                                        <p className="text-secondary fw-semibold small">Your request</p>   
                                        </div>
                                    
                                        <div className="text-muted">
                                        {new Date(exp.expenseDate).toLocaleDateString()}
                                        </div>
                                    </div>

                                    <div className="d-flex flex-column gap-3">
                                  
                                        <p className="mb-0 fw-bold">Expense amount: ${Number(exp.expenseAmount).toFixed(2)}</p>


                                        <Button size="sm">View Current Response</Button>
                                   
   
                                    </div>
                                </div>  
                            </Col></>
    )
}