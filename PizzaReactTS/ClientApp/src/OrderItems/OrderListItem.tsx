import { OrderItemType} from './OrderItems';
import {Wrapper, Img, P} from './OrderListItem.styles'

type Props = {
    item: OrderItemType;
}
const OrderListItem: React.FC<Props> =({item}) => {
    return(
    <Wrapper>
        <Img src = {item.recipeImgSrc} alt={item.recipeName} />
        <P>{item.quantity}</P>
        <P>{item.recipeName}</P>
    </Wrapper>
    );
}
export default OrderListItem;