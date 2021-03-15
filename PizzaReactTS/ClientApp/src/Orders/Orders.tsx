import { ChangeEvent, useState } from 'react';
import Button from '@material-ui/core/Button';
import { Wrapper, Center, Input, FlexC, Flex1, Flex2 } from './Orders.styles';
import OrderItems from '../OrderItems/OrderItems';

const Orders = () => {
    const [order, setOrder] = useState("");
    const [orderItems, setOrderItems] = useState(false);

    const handleInput = (event: ChangeEvent<HTMLInputElement>) => {
        setOrder(event.target.value);
    }
    const idString = order.toString();


    return (
        <Wrapper>
            <Center><h1>Orders</h1>
                <FlexC>
                    <Flex1 />
                    <Flex2>
                        <Input
                            id="standard"
                            variant="outlined"
                            value={order}
                            onChange={handleInput}
                        />
                        <Button className="flexbtn" variant="contained" color="primary"
                            onClick={() => setOrderItems(true)}>
                            Search
                        </Button>
                        <Button variant="contained" className="clear" onClick={() => setOrderItems(false)}>Clear</Button>
                    </Flex2>
                </FlexC>
                {orderItems ? <OrderItems orderId={idString} /> : null}
            </Center>

        </Wrapper>
    );
}
export default Orders;