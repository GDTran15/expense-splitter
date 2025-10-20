import axios from "axios";
import {  useEffect, useState } from "react"
import { Container,Row,Col,Button,Modal,Form, ModalBody } from "react-bootstrap"
import ExpenseComponent from "../Component/ExpenseComponent";
import OwnExpenseComponent from "../Component/OwnExpenseComponent";

export default function ExpensePage(){
    const [show,setShow] = useState(false);
    const [expenseName, setExpenseName] = useState("");
    const [amount, setAmount] = useState("");
    const [expenseList, setExpenseList] = useState([]);
    const [ownExpense,setOwnExpense] = useState([])
    
    const [shareOption,setShareOption] = useState("");  
    const [friendOrGroupList, setFriendOrGroupList] = useState([]);
    const [chooseLabel, setChooseLabel] = useState("");
    const [userToShare,setUserToShare] = useState(undefined);
   

    const user = JSON.parse(localStorage.getItem("user"));



 

    const handleCreateExpense = async (e) => {
        e.preventDefault();
        
        try {
            const res = await axios.post("https://localhost:7179/expense", {
                
                expenseAmount: amount,
                userId: user.userId,
                expenseName: expenseName,
                shareOption: shareOption,
                friendOrGroupId : userToShare
            });
            console.log(userToShare);
            await fetchOwnExpense();
            setExpenseName("");
            setAmount("");
           
            setShow(false);
            console.log(res);
        } catch(error) {
            console.log(error.response.data)
        }
    }

    const handleOptionChange = async (e) => {
        const selectedOption = e.target.value;
        setShareOption(selectedOption);
        setFriendOrGroupList([])
        setChooseLabel("");

        let url = "";
        switch(selectedOption){
            case "friend":
                url = "https://localhost:7179/friend";
                setChooseLabel("Choose friend to share");
                break;
            case "group":
                 url = "https://localhost:7179/group";
                setChooseLabel("Choose group to share");
                break;
            default:
                url = "";
           
            }
             if(url){
                try {
               const res = await axios.get(url,{
                    params: {userId : user.userId}
                });
                console.log(res)
                setFriendOrGroupList(res.data)
                
            } catch (error){
                console.log(error)
            }
        }


    }
    const handleItemChoose = (e) => {
        setUserToShare(e.target.value)
    }

   

    const fetchExpense = async () => {
        try{
            const res = await axios.get("https://localhost:7179/expense/share-request-user", {
                params: { userId: user.userId },
            });
            console.log(res);
            setExpenseList(res.data);
        } catch(error) {
            console.log(error);
        }
    }

     const fetchOwnExpense = async () => {
        try{
            const res = await axios.get("https://localhost:7179/expense", {
                params: { userId: user.userId },
            });
            console.log(res);
            setOwnExpense(res.data);
        } catch(error) {
            console.log(error);
        }
    }

    useEffect(() => {fetchExpense();}, []);
    useEffect(() => {fetchOwnExpense();}, []);
    
    //build the page you get me 
    return(
        <>
        <Container>
            <Row>
                <Col className="d-flex align-items-center justify-content-between">
                    <h5 className="fw-bold mb-0">Expenses</h5>
                    <Button size="sm" 
                            className="fw-bold rounded py-1 px-3"
                            onClick={() => {
                                setExpenseName("");
                                setAmount("");
                                
                                setShow(true);
                            }}
                    >Add Expense</Button>
                </Col>
            </Row> 
        </Container>

        <section className="mt-4">
            <Container>
            
            {expenseList.length === 0 && ownExpense.length === 0? (
                <p className="text-muted">No expenses yet. Create an Expense</p>
                ) : (
                    <Row className="gy-2">
                        {expenseList.map((exp) => (
                            <ExpenseComponent exp={exp} fetchExpense={fetchExpense}/>
                        ))}
                        {ownExpense.map((exp) => (
                            <OwnExpenseComponent exp={exp}/>
                        ))}
                    </Row>
                )}
            </Container>
        </section>

        <Modal        
            show={show}
            size="lg"
            aria-labelledby="contained-modal-title-vcenter"
            centered
            onHide={() => setShow(false)}
        >
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">
                Create New Expense       
                </Modal.Title>
            </Modal.Header>    
            <ModalBody >
                <Form onSubmit={handleCreateExpense}>
                    <Form.Group >
                        <Form.Label className="mt-2">Name</Form.Label>
                        <Form.Control
                            type="text"
                            placeholder="e.g Trip"
                            autoFocus
                            value={expenseName}
                            onChange={(e) => setExpenseName(e.target.value)}
                            required
                        />
                    </Form.Group>
                    <Form.Group >
                        <Form.Label className="mt-2">Amount $</Form.Label>
                        <Form.Control
                            type="text"
                            placeholder="e.g 10000"
                            autoFocus
                            value={amount}
                            onChange={(e) => setAmount(e.target.value)}
                            required
                            className=""
                        />
                    </Form.Group>
                    <Form.Group >
                        <Form.Label className="mt-2">Share option </Form.Label>
                        <Form.Select onChange={handleOptionChange}>
                        <option selected>Open this select menu</option>
                        <option value="friend">Friend</option>
                        <option value="group">Group</option>
                        </Form.Select>
                    </Form.Group>
                    { shareOption != ""? 
                            <Form.Group >
                    <Form.Label className="mt-2">{chooseLabel}</Form.Label>
                        <Form.Select onChange={handleItemChoose}>
                            <option selected>Open this select menu</option>
                         {friendOrGroupList.map(item => (
                            <option value={item.friendId || item.groupId}>{item.groupName || item.friendName}</option>
                         ))} 
                        </Form.Select>
                    </Form.Group>
                   
                      : "" }
                       
                    
                    <div className="d-flex gap-2 mt-3">
                        <Button variant="secondary" onClick={() => setShow(false)} className="flex-fill">Cancel</Button>
                        <Button onClick={() => setShow(false)} className="flex-fill" type="submit">Create</Button>
                    </div>
                </Form>
              
            </ModalBody>
        </Modal>
        
        

        </>
    )
}