<?php

class Consultas{
    private $conexion;
    private $results;
    private $mysqli;
    
    public function __construct() {
        $this->conexion = new Conexion();
        $this->mysqli = $this->conexion->mysqli;
    }
    ////---------------USUARIO------------------------------
    public function insertUsuario($datos)
    {
        $query = "INSERT INTO `paqueteria`.`usuarios` (`nombre`, `correo`, `direccion`, `telefono`, `tipo`)
         VALUES ('".$datos['nombre']."', '".$datos['correo']."', '".$datos['direccion']."',
         '".$datos['telefono']."', '".$datos['tipo']."')";
          $res = $this->mysqli->query($query);
            if($res)
            {
                return true;
            }
            else
            {
                return false;
            } 
    }
    
    public function selectUsuario()
    {
        $query = "select * from usuarios";
        $res = $this->mysqli->query($query);
        $this->results = $res->fetch_all(MYSQLI_ASSOC);
        return $this->results;
    }
    
    public function updateUsuario($datos)
    {
        $query = "UPDATE `paqueteria`.`usuarios` SET `nombre`='".$datos['nombre']." ',
            `correo`='".$datos['correo']." ', `direccion`='".$datos['direccion']." ', `telefono`='".$datos['tel']." ',
            `tipo`='".$datos['tipo']." ' WHERE `idUsuario`='".$datos['id']." ';";
        
        $res = $this->mysqli->query($query);
            if($res)
            {
                return true;
            }
            else
            {
                return false;
            } 
    }
    
    public function deleteUsuario($id)
    {
        $query = "DELETE FROM `paqueteria`.`usuarios` WHERE `usuarios`.`idUsuario` = '".$id['id']."'";
        $res = $this->mysqli->query($query);
            if($res)
            {
                return true;
            }
            else
            {
                return false;
            } 
        
    }
    ///-----------------------------CLIENTE------------------------------------------
    
    public function insertCliente($datos)
    {
        $query = "INSERT INTO `paqueteria`.`cliente` (`nombre`, `telefono`, `direccion`, `email`) 
        VALUES ('".$datos['nombre']."', '".$datos['telefono']."', '".$datos['direccion']."', '".$datos['email']."')";
        
        $res = $this->mysqli->query($query);
            if($res)
            {
                return true;
            }
            else
            {
                return false;
            } 
    }
    
    public function selectCliente()
    {
        $query = "select * from cliente";
        $res = $this->mysqli->query($query);
        $this->results = $res->fetch_all(MYSQLI_ASSOC);
        return $this->results;
    }
    
    public function selectClienteN($datos)
    {
        $query = "SELECT * FROM `cliente` WHERE `nombre` = '".$datos['nombre']."'";
        $res = $this->mysqli->query($query);
        $this->results = $res->fetch_all(MYSQLI_ASSOC);
        return $this->results;
    }
    
    public function updateCliente($datos)
    {
        $query = "UPDATE `paqueteria`.`cliente` 
            SET `nombre`='".$datos['nombre']."', `telefono`='".$datos['telefono']."',
            `direccion`='".$datos['direccion']."', `email`='".$datos['email']."' 
            WHERE `idCliente`='".$datos['id']."'";
            
            $res = $this->mysqli->query($query);
            if($res)
            {
                return true;
            }
            else
            {
                return false;
            } 
    }
    
    public function deleteCliente($datos)
    {
        $query = "DELETE FROM `paqueteria`.`cliente` WHERE `cliente`.`nombre` = '".$datos['nombre']."'";
        $res = $this->mysqli->query($query);
            if($res)
            {
                return true;
            }
            else
            {
                return false;
            }
    }
    
     public function dCliente()
    {
          $query = "delete  from cliente";
          $res = $this->mysqli->query($query);
        
            if($res)
            {
                return true;
            }
            else
            {
                return false;
            }
    }
    ///--------------ADMINISTRADORES----------------------------------------------------------------
    
    public function insertAdministrador($datos)
    {
        $query = "INSERT INTO `paqueteria`.`administradores` (`user`, `password`, `Nombre`) 
        VALUES ('".$datos['user']."', '".$datos['password']."', '".$datos['nombre']."')";
        
        $res = $this->mysqli->query($query);
            if($res)
            {
                return true;
            }
            else
            {
                return false;
            } 
    }
    
    public function selectAdministrador()
    {
        $query = "select idAdmin,user, Nombre  from administradores";
        
        $res = $this->mysqli->query($query);
        $this->results = $res->fetch_all(MYSQLI_ASSOC);
        return $this->results;
        
    }
    
    public function rPw($datos)
    {
        $query = "select password from administradores where user = '".$datos['nombre']."'";
        $res = $this->mysqli->query($query);
        $this->results = $res->fetch_all(MYSQLI_ASSOC);
        return $this->results;
    }
    
    public function updateAdministrador($datos)
    {
        $query = "UPDATE `paqueteria`.`administradores` 
            SET `user`='".$datos['user']."', `password`='".$datos['pw']."', `Nombre`='".$datos['nombre']."' WHERE `idAdmin`='".$datos['id']."';";
            
            $res = $this->mysqli->query($query);
            if($res)
            {
                return true;
            }
            else
            {
                return false;
            } 
    }
    
    public function deleteAdministrador($id)
    {
        $query = "DELETE FROM `paqueteria`.`administradores` WHERE `administradores`.`idAdmin` = '".$id['id']."'";
        $res = $this->mysqli->query($query);
            if($res)
            {
                return true;
            }
            else
            {
                return false;
            }
    }
    /////,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
    
        public function insertPedido($datos)
    {
        //La fecha hay que ponerla con el formato dd/mm/aaaa
        //$query = "INSERT INTO `paqueteria`.`pedidos` (`producto`, `descripcion`, `fechaRecepcion`, `fechaEntrega`, `comienzo`, `destino`, `usuarios_idUsuario`, `cliente_idcliente`) VALUES ('".$datos['producto']."', '".$datos['descripcion']."', '".$datos['fechaI']."', '".$datos['fechaE']."', '".$datos['inicio']."', '".$datos['destino']."', '".$datos['idUsuario']."', '".$datos['idCliente']."')";
        $query = "INSERT INTO `paqueteria`.`pedidos` (`idPedido`, `producto`, `descripcion`, `fechaRecepcion`, `fechaEntrega`, `comienzo`, `destino`, `cliente_idcliente`, `administradores_idAdmin`) VALUES (NULL,'".$datos['producto']."', '".$datos['descripcion']."', '".$datos['fechaI']."', '".$datos['fechaE']."', '".$datos['inicio']."', '".$datos['destino']."', '".$datos['idCliente']."','".$datos['idUsuario']."')";
        $res = $this->mysqli->query($query);
        if($res)
        {
            return true;
        }
        else
        {
            return false;
        } 
    }

     public function insertMovimiento($datos)
    {
        $query = "INSERT INTO `paqueteria`.`movimientos` (`fecha`, `tipo`, `observaciones`, `pedidos_idPedido`, `status`, `lugarActual`) VALUES ('".$datos['fecha']."', 'nada', '".$datos['observaciones']."', '".$datos['idPedido']."', '".$datos['status']."', '".$datos['lug_Actual']."');";
        $res = $this->mysqli->query($query);
        if($res)
        {
            return true;
        }
        else
        {
            return false;
        } 
    }

    public function selectMovimientos($datos)
    {
        $query = "SELECT `movimientos`.`fecha`, `movimientos`.`tipo`, `movimientos`.`observaciones`, `movimientos`.`pedidos_idPedido` as 'numPedido', `movimientos`.`status`, `movimientos`.`lugarActual` as 'lugar', `pedidos`.`producto` FROM `movimientos` left join `pedidos` on movimientos.pedidos_idPedido = pedidos.idPedido WHERE pedidos.idPedido = ".$datos['codigo'].";";
        $res = $this->mysqli->query($query);
        $this->results = $res->fetch_all(MYSQLI_ASSOC);
        return $this->results;
    }
    
    public function leerpedidos()
    {
        $query = "select * from leerpedidos;";
        $res = $this->mysqli->query($query);
        $this->results = $res->fetch_all(MYSQLI_ASSOC);
        return $this->results;
    }
    public function todoMovi()
    {
         $query = 'select  pedidos.idPedido as "Codigo", movimientos.fecha as "Fecha", movimientos.observaciones 
         as "Observaciones" , pedidos.descripcion as "Pedido", movimientos.status as "Estado",
         movimientos.lugarActual as "Lugar" from movimientos
         left join pedidos on pedidos.idPedido = movimientos.pedidos_idPedido;';
        $res = $this->mysqli->query($query);
        $this->results = $res->fetch_all(MYSQLI_ASSOC);
        return $this->results;
    }
    
    
    
    ///---------------------------------------------------------------------------------------------
}

//$miConsulta = new Consultas();
//$miConsulta->consultar();