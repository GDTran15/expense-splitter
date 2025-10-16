
import { Nav,Container,Row,Button } from 'react-bootstrap';
import style from '../css/navbar.module.css';

export default function NavBarComponent(){
    return (
        <>
       
        <nav className='bg-white  '>
            <div className={style.navbarBorder}>
                 <Container>
                <Row >
                    <div className=' d-flex align-content-center justify-content-between'>
               
                    <h3>SplitWise</h3> 
                    <div className='d-flex align-items-center gap-2'>
                        <p className='mb-0'>Welcome, username</p>
                        <Button size='sm'>Logout</Button>
                    </div>  
                    

                    </div>
                </Row>
            </Container>
            </div>
            <Container>
                <Nav
                activeKey="/home"
                onSelect={(selectedKey) => alert(`selected ${selectedKey}`)}
                
                >
                <Nav.Item>
                    <Nav.Link className="text-secondary fw-semibold">DashBoard</Nav.Link>
                </Nav.Item>
                <Nav.Item>
                    <Nav.Link className="text-secondary fw-semibold">Groups</Nav.Link>
                </Nav.Item>
                <Nav.Item>
                    <Nav.Link className="text-secondary fw-semibold">Friends</Nav.Link>
                </Nav.Item>
                <Nav.Item>
                    <Nav.Link className="text-secondary fw-semibold">
                    Expense
                    </Nav.Link>
                </Nav.Item>
            </Nav>
            </Container>
             
         </nav>
            
       
            
             
        </>
    )
}