import { Navb, Brand, Ul, } from './NavBar.styles';
const NavBar = (props: {
    brand: { name: string; to: string },
    links: Array<{ name: string, to: string }>
}) => {
    const { brand, links } = props;
    const NavLinks: any = () => links.map(
        (link: { name: string, to: string }) => <li key={link.name}><a href={link.to}>{link.name}</a></li>);
    return (
        <Navb>
            <Brand href={brand.to}>{brand.name}</Brand>
            <Ul>
                <NavLinks />
            </Ul>
        </Navb>
    );
}
export default NavBar;
