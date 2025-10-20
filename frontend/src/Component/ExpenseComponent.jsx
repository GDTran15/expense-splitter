import axios from "axios";
import { Col,Button } from "react-bootstrap";

export default function ExpenseComponent({exp, fetchExpense}){
    const user = JSON.parse(localStorage.getItem("user"));
    const handleResponseFromUser = async (res,shareId,expenseId,ownerId,amountToPay) => {
        try{
        await axios.put(`https://localhost:7179/share-request/${shareId}`,{
            
            ExpenseOwnerId: ownerId,
            ExpenseId : expenseId,
            isAccepted : res,
            UserId : user.userId,
            AmountToPay : amountToPay
        })
        fetchExpense();
    }catch (err){
        console.log(err)
    }
    }

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
                                        <p className="text-secondary fw-semibold small">{exp.userId === user.userId ? "Your request" :  "Request by " +exp.ownerName}</p>   
                                        </div>
                                    
                                        <div className="text-muted">
                                        {new Date(exp.expenseDate).toLocaleDateString()}
                                        </div>
                                    </div>

                                    <div className="d-flex flex-column gap-3">
                                    <div className="fw-bold text-start">
                                        <p className="mb-0">Expense amount: ${Number(exp.expenseAmount).toFixed(2)}</p>
                                        <p className="mb-0">You have to pay: ${Number(exp.amountToPay).toFixed(2)}</p>
                                    </div >
                                    
                                        
                                        <div className="d-flex gap-2 justify-content-end"> 
                                        <Button variant="danger" size="sm" onClick={() => handleResponseFromUser(false,exp.shareRequestId,exp.expenseId,exp.userId,exp.amountToPay)}>Reject</Button>
                                        <Button variant="success" size="sm" onClick={() => handleResponseFromUser(true,exp.shareRequestId,exp.expenseId,exp.userId,exp.amountToPay)}>Accept</Button>
                                        </div>
                                      
                                    </div>
                                </div>  
                            </Col></>
    )
}