import { Route } from 'react-router';
import Menu from './Menu/Menu';
import Home from './Home/Home';
import NavBar from './NavBar/NavBar';
import Orders from './Orders/Orders';

const navigation = {
  brand: { name: "FakePizza", to: "/" },
  links: [
    { name: "Menu", to: "/menu" },
    { name: "Orders", to: "/orders" }
  ]
};

function App() {
  const { brand, links } = navigation;

  return (
    <>
      <NavBar brand={brand} links={links} />
      <Route exact path='/' component={Home} />
      <Route path='/menu' component={Menu} />
      <Route path='/orders' component={Orders} />
    </>
  );
}
export default App;
