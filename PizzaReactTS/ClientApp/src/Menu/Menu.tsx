import { useState } from 'react';
import { useQuery } from 'react-query';
//Components
import Drawer from '@material-ui/core/Drawer';
import LinearProgress from '@material-ui/core/LinearProgress';
import Grid from '@material-ui/core/Grid';
import Badge from '@material-ui/core/Badge';
import Cart from '../Cart/Cart';
import { ReactComponent as Pizza } from '../img/pizza.svg';
import Container from '@material-ui/core/Container';
import Button from '@material-ui/core/Button';
import OrderItems from '../OrderItems/OrderItems';

//Styles
import { Wrapper, StyledButton, Sticky, Center, TopContent } from '../Menu/Menu.styles';
import Item from '../Item/Item';
//Types
export type CartItemType = {
  recipeId: number;
  recipeName: string;
  recipeImgSrc: string;
  recipePrice: number;
  amount: number;
}


const getProducts = async (): Promise<CartItemType[]> =>
  await (await fetch('https://localhost:44379/P/GetRecipes')).json();

const Menu = () => {
  const [cartOpen, setCartOpen] = useState(false);
  const [cartItems, setCartItems] = useState([] as CartItemType[]);
  const [orderId, setOrderId] = useState("");
  const [popupOpen, setPopupOpen] = useState(false);

  const { data, isLoading, error } = useQuery<CartItemType[]>(
    'recipes',
    getProducts
  );
  const clearCart = () => setCartItems([]);
  const closeCart = () => setCartOpen(false);

  const getTotalItems = (items: CartItemType[]) => items.reduce((tot: number, item) => tot + item.amount, 0);
  const handleAddToCart = (clickedItem: CartItemType) => {
    setCartItems(prev => {
      const isItemInCart = prev.find(item => item.recipeId === clickedItem.recipeId)

      if (isItemInCart) {
        return prev.map(item =>
          item.recipeId === clickedItem.recipeId
            ? { ...item, amount: item.amount + 1 }
            : item
        );
      }

      return [...prev, { ...clickedItem, amount: 1 }];
    })
  };
  const passOrderId = (id: string) => setOrderId(id);
  const openPopup = () => setPopupOpen(true);

  const handleRemoveFromCart = (recipeId: number) => {
    setCartItems(prev =>
      prev.reduce((tot, item) => {
        if (item.recipeId === recipeId) {
          if (item.amount === 1) return tot;
          return [...tot, { ...item, amount: item.amount - 1 }];
        } else {
          return [...tot, item];
        }
      }, [] as CartItemType[])
    );
  };


  if (isLoading) return <LinearProgress />
  if (error) return <div>Something went wrong...</div>

  return (
    <Wrapper>
      <Button
        variant="contained" color="primary"
        onClick={() => setPopupOpen(true)}
      >Popup</Button>
      <Drawer anchor='top' open={popupOpen} onClose={() => setPopupOpen(false)}>
        <TopContent>
          <Center>
            <h2>Your Order Number is</h2>
            <h1>{orderId}</h1>
          </Center>
          <OrderItems orderId={orderId} />
        </TopContent>

      </Drawer>
      <Drawer anchor='right' open={cartOpen} onClose={() => setCartOpen(false)}>
        <Cart
          cartItems={cartItems}
          addToCart={handleAddToCart}
          removeFromCart={handleRemoveFromCart}
          clearCart={clearCart}
          closeCart={closeCart}
          passOrderId={passOrderId}
          openPopup={openPopup}
        />
      </Drawer>
      <Sticky>
        <StyledButton onClick={() => setCartOpen(true)}>
          <Badge badgeContent={getTotalItems(cartItems)} color='error'>
            <Pizza width="50px" height="50px" />
          </Badge>
        </StyledButton>
      </Sticky>
      <Container maxWidth="lg">
        <Grid container spacing={2}>
          {data?.map(item => (
            <Grid item key={item.recipeId} xs={12} sm={4} md={3}>
              <Item item={item} handleAddToCart={handleAddToCart} />
            </Grid>
          ))}
        </Grid>
      </Container>
    </Wrapper>
  );
}
export default Menu;