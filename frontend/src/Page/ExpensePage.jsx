import axios from "axios";
import { useState } from "react"
import { Container,Row,Col,Button ,Modal,Form} from "react-bootstrap"

export default function ExpensePage(){
    const [show,setShow] = useState(false);
    const [expenseAmount,setExpenseAmount] = useState(false);
    const [imagePath ,setImagePath] = useState("");
    const user = JSON.parse(localStorage.getItem("user"));
    const handleSubmit = async (e) => {
        e.preventDefault();
        
        try{
        const res = await axios.post("https://localhost:7179/expense",{
            ExpenseAmount : expenseAmount,
            UserId : user.userId,
        });
        console.log(res);
    } catch(error){
        console.log(error.response.data)
    }
    }
    

    return(
          <>
        <Container>
            <Row>
                <Col className="d-flex align-items-center justify-content-between">
                    <h5 className="fw-bold">Expense</h5>
                    <Button size="sm" className="fw-bold rounded py-1 px-3"
                    onClick={() => setShow(true)}
                    >Create New Expense</Button>
                </Col>
            </Row>
        </Container>

        {/* <section className="mt-5">
            <Container>
                <Row className="gap-3">
                    {groupList && groupList.map(group => 
                        <GroupComponent key={group.groupId} groupData={group}/>
                    )
                    }
                </Row>
            </Container>
        </section> */}
         
         
         
         
         
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
      <Modal.Body>
         <Form onSubmit={handleSubmit}>
            <Form.Group className="mb-3">
              <Form.Label>Expense Amount</Form.Label>
              <Form.Control
                type="number"
                placeholder="e.g 1000"
                autoFocus
                value={expenseAmount}
                onChange={(e) => setExpenseAmount(e.target.value)}
                 />
            </Form.Group>
             <Form.Group controlId="formFile" className="mb-3">
                  <Form.Label>Input Expense Evidence</Form.Label>
             <Form.Control type="file" accept="image/png, image/jpeg"
                          />
          </Form.Group>
            <div className="d-flex gap-2">
                 <Button variant="secondary" onClick={() => setShow(false)} className="flex-fill">Cancel</Button>
                 <Button onClick={() => setShow(false)} className="flex-fill" type="submit">Create</Button>
            </div>
          </Form>
          {/*error === "" ? "" : <p className="text-danger">*{error}</p>*/}
      </Modal.Body>
    </Modal>
        </>
    )
}